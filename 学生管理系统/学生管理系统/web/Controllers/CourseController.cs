using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class CourseController : Controller
    {
        //
        // GET: /Course/
        DBA.BLL.Course bll = new DBA.BLL.Course();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
               DBA.Model.Course  model= new DBA.Model.Course();
                return View(model);
            }
            else
            {
                return View(bll.GetModel(Convert.ToInt32(ID)));    
            }
           
        }

        [HttpPost]
        public ActionResult Edit(DBA.Model.Course model)
        {
            bll.Edit(model);
            return RedirectToAction("CourseManage");

        }

        [HttpPost]
        public JsonResult Del(string ID)
        {
            return Json(bll.Delete(Convert.ToInt32(ID)));

        }

        public ActionResult CourseManage(Conris.DBA.ViewModel.CourseSearch model)
        {
            return View(model);
        }

        public PartialViewResult CourseSearch(Conris.DBA.ViewModel.CourseSearch model)
        {
            return PartialView(model);
        }

        public PartialViewResult CourseList(Conris.DBA.ViewModel.CourseSearch model)
        {
            return PartialView(bll.SearchProject(model));
        }
    }
}
