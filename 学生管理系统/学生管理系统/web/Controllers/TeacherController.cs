using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/
        DBA.BLL.Teacher bll = new DBA.BLL.Teacher();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                DBA.Model.Teacher model = new DBA.Model.Teacher();
                return View(model);
            }
            else
            {
                DBA.Model.Teacher empmodel = bll.GetModel(Convert.ToInt32(ID));
                return View(empmodel);
            }

        }

        [HttpPost]
        public ActionResult Edit(DBA.Model.Teacher model)
        {
            bll.Edit(model);
            return RedirectToAction("TeacherManage");

        }

        [HttpPost]
        public JsonResult Del(string ID)
        {
            return Json(bll.Delete(Convert.ToInt32(ID)));

        }

        public ActionResult TeacherManage(Conris.DBA.ViewModel.TeacherSearch model)
        {
            return View(model);
        }

        public PartialViewResult TeacherSearch(Conris.DBA.ViewModel.TeacherSearch model)
        {
            return PartialView(model);
        }

        public PartialViewResult TeacherList(Conris.DBA.ViewModel.TeacherSearch model)
        {
            return PartialView(bll.SearchProject(model));
        }
    }
}
