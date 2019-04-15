using miniecommerce.BLL.Concrete;
using miniecommerce.DAL.Concrete;
using miniecommerce.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;

namespace miniecommerce.MVC.Controllers
{
    public class UserController : Controller
    {
        UserManager userManager = new UserManager(new UserRepository());
        BasketManager basketManager = new BasketManager(new BasketRespository());
        #region Login 
        [HttpGet]
        [Route("User/SignOut")]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("User/SignUp")]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("User/SignUp")]
        public ActionResult SignUp(User user)
        {
            if (user != null)
            {
                user.CreatedDate = DateTime.Now;
                user.CreatedUserID = 1;
                userManager.Add(user);
                return RedirectToAction("Login", "User");
            }
            else
            {
                ViewBag.HataBaslik = "Boş Alan Bırakmayınız !".ToUpper();
                ViewBag.HataAciklama = "Tüm alanları doldurunuz.!";
                return View(user);
            }

        }
        [HttpGet]
        [Route("User/Login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("User/Login")]
        public ActionResult Login(User user)
        {
            if (string.IsNullOrEmpty(user.NickName) && string.IsNullOrEmpty(user.Password))
            {
                ViewBag.HataBaslik = "Boş Alan Bırakmayınız !".ToUpper();
                ViewBag.HataAciklama = "Kullanıcı Adı veya Şifre Boş Geçilemez";
                return View(user);
            }
            else
            {
                List<User> _user = userManager.GetAll(u => u.NickName == user.NickName && u.Password == user.Password);
                if (_user.Count > 0)
                {
                    foreach (var item in _user)
                    {
                        Session["UserID"] = item.Id;
                        Session["NameSurname"] = item.UserName + " " + item.UserSurName;
                        break;
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {

                    ViewBag.HataBaslik = "Hatalı Giriş".ToUpper();
                    ViewBag.HataAciklama = "Kullanıcı Adı veya Şifre Hatalı Giriş Yapıldı. <br> Lütfen Tekrar Deneyiniz !";
                    return View(user);
                }
            }
        }
        #endregion
    }
}