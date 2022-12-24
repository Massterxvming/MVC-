using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        DBA.BLL.Users bll = new DBA.BLL.Users();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string LoginName, string LoginPwd)
        {
            string IsLogin = bll.Login(LoginName, LoginPwd, false);
            return Json(IsLogin);
        }

        [HttpPost]
        public JsonResult LogOff()
        {
            return Json(bll.LogOut());
        }
    }
}
