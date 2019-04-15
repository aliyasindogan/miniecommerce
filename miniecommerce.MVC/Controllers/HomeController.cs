using miniecommerce.BLL.Concrete;
using miniecommerce.DAL.Concrete;
using miniecommerce.ENTITIES.Concrete;
using miniecommerce.ENTITIES.Concrete.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace miniecommerce.MVC.Controllers
{
    public class HomeController : Controller
    {

        #region Manager
        ProductManager productManager = new ProductManager(new ProductRepository());
        #endregion

        [HttpGet]
        [Route("Home/Index")]
        public ActionResult Index()
        {
            return View(productManager.GetAll(u => u.Id < 12));
        }
        [HttpGet]
        [Route("Home/Iletisim")]
        public ActionResult Iletisim()
        {
            return View();
        }
        [HttpGet]
        [Route("Home/Proje")]
        public ActionResult Proje()
        {
            return View();
        }
    }
}