using miniecommerce.BLL.Concrete;
using miniecommerce.DAL.Concrete;
using miniecommerce.ENTITIES.Concrete;
using miniecommerce.ENTITIES.Concrete.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace miniecommerce.MVC.Controllers
{
    public class BasketController : Controller
    {
        BasketManager basketManager = new BasketManager(new BasketRespository());
        ProductManager productManager = new ProductManager(new ProductRepository());

        #region Basket
        [HttpGet]
        [Route("Basket/Payment")]
        public ActionResult Payment()
        {
            //Ödeme
            if (Session["UserID"] != null)
            {
                int _userID = Convert.ToInt32(Session["UserID"]);
                List<Basket> basket = basketManager.GetAll(x => x.IsSales == false && x.UserID == _userID);
                foreach (var item in basket)
                {
                    Basket _basket = basketManager.GetById(item.Id);
                    _basket.IsSales = true;
                    _basket.UpdatedDate = DateTime.Now;
                    _basket.UpdatedUserID = _userID;
                    basketManager.Update(_basket);
                }
                return RedirectToAction("BasketList", "Basket");
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        [HttpGet]
        [Route("Basket/BasketList")]
        public ActionResult BasketList()
        {
            if (Session["UserID"] != null)
            {
                int _userID = Convert.ToInt32(Session["UserID"]);
                decimal toplam = basketManager.Sum(x => x.UserID == _userID && x.IsSales == false, x => x.ProductPriceTotal);
                decimal kdv = toplam * 18 / 100;
                ViewBag.Kdv = kdv;
                ViewBag.SiparisToplami = toplam;
                ViewBag.GenelToplam = toplam + kdv;
                return View(basketManager.GetBasketListByUserID(x => x.UserID == _userID && x.IsSales == false));
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        [HttpGet]
        [Route("Basket/MyAccount")]
        public ActionResult MyAccount()
        {
            if (Session["UserID"] != null)
            {
                int _userID = Convert.ToInt32(Session["UserID"]);
                return View(basketManager.GetBasketListByUserID(x => x.UserID == _userID));
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        [Route("Basket/BasketAdd")]
        public ActionResult BasketAdd()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Basket/BasketAdd")]
        //[Route("Home/BasketAdd/{ProductID}/{Quantity}")]
        public ActionResult BasketAdd(ProductBasketViewModel productViewModel)
        {
            if (Session["UserID"] != null)
            {

                Basket basket = new Basket();
                Product product = productManager.GetById(productViewModel.ProductID);
                basket.ProductID = productViewModel.ProductID;
                basket.UserID = Convert.ToInt32(Session["UserID"]);
                if (productViewModel.Quantity > 0)
                    basket.Quantity = productViewModel.Quantity;
                else
                    basket.Quantity = 1;
                basket.ProductPrice = product.ProductPrice;
                basket.ProductPriceTotal = Convert.ToDecimal(basket.Quantity) * product.ProductPrice;
                basket.CreatedDate = DateTime.Now;
                basket.CreatedUserID = Convert.ToInt32(Session["UserID"]);
                basket.SortNumber = basketManager.Max(x => x.SortNumber) + 1;
                basket.IsActive = true;
                basketManager.Add(basket);
                return RedirectToAction("BasketList", "Basket");

            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }


        #endregion
    }
}