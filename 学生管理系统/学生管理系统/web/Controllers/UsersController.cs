using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Users/
        DBA.BLL.Users bll = new DBA.BLL.Users();
        DBA.BLL.Course cbll = new DBA.BLL.Course();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
               DBA.Model.Users  model= new DBA.Model.Users();
                return View(model);
            }
            else
            {
                return View(bll.GetModel(Convert.ToInt32(ID)));    
            }
           
        }

        [HttpPost]
        public ActionResult Edit(DBA.Model.Users model)
        {
            bll.Edit(model);
            return RedirectToAction("UsersManage");

        }

        [HttpPost]
        public JsonResult Del(string ID)
        {
            return Json(bll.Delete(Convert.ToInt32(ID)));

        }

        public ActionResult UsersManage(Conris.DBA.ViewModel.UsersSearch model)
        {
            return View(model);
        }

        public PartialViewResult UsersSearch(Conris.DBA.ViewModel.UsersSearch model)
        {
            return PartialView(model);
        }

        public PartialViewResult UsersList(Conris.DBA.ViewModel.UsersSearch model)
        {
            return PartialView(bll.SearchProject(model));
        }

        public ActionResult ZManage(Conris.DBA.ViewModel.UsersSearch model)
        {
            return View(model);
        }

        public PartialViewResult ZSearch(Conris.DBA.ViewModel.UsersSearch model)
        {
            return PartialView(model);
        }

        public PartialViewResult ZList(Conris.DBA.ViewModel.UsersSearch model)
        {
            List<DBA.Model.Users> list = bll.SearchZF(model);
            list = list.OrderByDescending(m=>Convert.ToInt32(m.LoginPSD)).ToList();
            return PartialView(list);
        }

        public ActionResult TManage(Conris.DBA.ViewModel.UsersSearch model)
        {
            return View(model);
        }

        public PartialViewResult TSearch(Conris.DBA.ViewModel.UsersSearch model)
        {
            return PartialView(model);
        }

        public PartialViewResult TList(Conris.DBA.ViewModel.UsersSearch model)
        {
            List<DBA.Model.Course> list = cbll.GetModelList("");
            string carr = "";
            foreach (var item in list)
            {
                carr = carr + item.ID + ",";
            }

            string carrname = "";
            foreach (var item in list)
            {
                carrname = carrname + item.CourseName + ",";
            }
            TempData["carrname"] = carrname;
            List<DBA.Model.Users> listuser = bll.SearchBB(carr,model);
            listuser = listuser.OrderByDescending(m => Convert.ToInt32(m.LoginPSD)).ToList();
            return PartialView(listuser);
        }
    }
}
