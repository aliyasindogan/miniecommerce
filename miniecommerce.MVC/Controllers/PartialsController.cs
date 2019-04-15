using miniecommerce.BLL.Concrete;
using miniecommerce.DAL.Concrete;
using miniecommerce.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace miniecommerce.MVC.Controllers
{
    public class PartialsController : Controller
    {
        BasketManager basketManager = new BasketManager(new BasketRespository());

        [HttpGet]
        [Route("Partials/BasketPartialView")]
        public PartialViewResult BasketPartialView()
        {
            int _userID = Convert.ToInt32(Session["UserID"]);
            Basket basket = new Basket();
            basket.Quantity = basketManager.Sum(x => x.UserID == _userID && x.IsSales == false, x => x.Quantity);
            return PartialView(basket)   ;
        }

    }
}