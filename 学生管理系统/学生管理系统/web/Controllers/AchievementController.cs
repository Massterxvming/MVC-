using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class AchievementController : Controller
    {
        //
        // GET: /Achievement/
        DBA.BLL.Achievement bll = new DBA.BLL.Achievement();
        DBA.BLL.Teacher tbll = new DBA.BLL.Teacher();
        DBA.BLL.Course cbll = new DBA.BLL.Course();
    
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(string ID)
        {
            //laoshi
            List<SelectListItem> select1 = new List<SelectListItem>();
            select1.Add(new SelectListItem
            {
                Text = "请选择",
                Value = ""
            });
            List<DBA.Model.Teacher> list = tbll.GetModelList("");
            for (int i = 0; i < list.Count; i++)
            {
                select1.Add(new SelectListItem
                {
                    Text = list[i].TeacherName,
                    Value = list[i].ID.ToString()
                });
            };
            ViewData["TeacherID"] = new SelectList(select1, "Value", "Text", "");
            //kecheng
            List<SelectListItem> select2 = new List<SelectListItem>();
            select2.Add(new SelectListItem
            {
                Text = "请选择",
                Value = ""
            });
            List<DBA.Model.Course> list2 = cbll.GetModelList("");
            for (int i = 0; i < list2.Count; i++)
            {
                select2.Add(new SelectListItem
                {
                    Text = list2[i].CourseName,
                    Value = list2[i].ID.ToString()
                });
            };
            ViewData["CourseID"] = new SelectList(select2, "Value", "Text", "");
            //jiaoshi
            List<SelectListItem> select3 = new List<SelectListItem>();
            select3.Add(new SelectListItem
            {
                Text = "请选择",
                Value = ""
            });
         
            if (string.IsNullOrEmpty(ID))
            {
               DBA.Model.Achievement  model= new DBA.Model.Achievement();
                return View(model);
            }
            else
            {
                return View(bll.GetModel(Convert.ToInt32(ID)));    
            }
           
        }

        [HttpPost]
        public ActionResult Edit(DBA.Model.Achievement model)
        {
            bll.Edit(model);
            return RedirectToAction("ScheduleManage");

        }

        [HttpPost]
        public JsonResult Del(string ID)
        {
            return Json(bll.Delete(Convert.ToInt32(ID)));

        }

        public ActionResult ScheduleManage(Conris.DBA.ViewModel.AchievementSearch model)
        {
            return View(model);
        }

        public PartialViewResult ScheduleSearch(Conris.DBA.ViewModel.AchievementSearch model)
        {
            //laoshi
            List<SelectListItem> select1 = new List<SelectListItem>();
            select1.Add(new SelectListItem
            {
                Text = "请选择",
                Value = ""
            });
            List<DBA.Model.Teacher> list = tbll.GetModelList("");
            for (int i = 0; i < list.Count; i++)
            {
                select1.Add(new SelectListItem
                {
                    Text = list[i].TeacherName,
                    Value = list[i].ID.ToString()
                });
            };
            ViewData["TeacherID"] = new SelectList(select1, "Value", "Text", "");
            //kecheng
            List<SelectListItem> select2 = new List<SelectListItem>();
            select2.Add(new SelectListItem
            {
                Text = "请选择",
                Value = ""
            });
            List<DBA.Model.Course> list2 = cbll.GetModelList("");
            for (int i = 0; i < list2.Count; i++)
            {
                select2.Add(new SelectListItem
                {
                    Text = list2[i].CourseName,
                    Value = list2[i].ID.ToString()
                });
            };
            ViewData["CourseID"] = new SelectList(select2, "Value", "Text", "");
         
            return PartialView(model);
        }

        public PartialViewResult ScheduleList(Conris.DBA.ViewModel.AchievementSearch model)
        {
            return PartialView(bll.SearchProject(model));
        }

        //单科排名
        public ActionResult DManage(Conris.DBA.ViewModel.AchievementSearch model)
        {
            return View(model);
        }

        public PartialViewResult DSearch(Conris.DBA.ViewModel.AchievementSearch model)
        {
            //laoshi
            List<SelectListItem> select1 = new List<SelectListItem>();
            select1.Add(new SelectListItem
            {
                Text = "请选择",
                Value = ""
            });
            List<DBA.Model.Teacher> list = tbll.GetModelList("");
            for (int i = 0; i < list.Count; i++)
            {
                select1.Add(new SelectListItem
                {
                    Text = list[i].TeacherName,
                    Value = list[i].ID.ToString()
                });
            };
            ViewData["TeacherID"] = new SelectList(select1, "Value", "Text", "");
            //kecheng
            List<SelectListItem> select2 = new List<SelectListItem>();
            select2.Add(new SelectListItem
            {
                Text = "请选择",
                Value = ""
            });
            List<DBA.Model.Course> list2 = cbll.GetModelList("");
            for (int i = 0; i < list2.Count; i++)
            {
                select2.Add(new SelectListItem
                {
                    Text = list2[i].CourseName,
                    Value = list2[i].ID.ToString()
                });
            };
            ViewData["CourseID"] = new SelectList(select2, "Value", "Text", "");

            return PartialView(model);
        }

        public PartialViewResult DList(Conris.DBA.ViewModel.AchievementSearch model)
        {
            List<DBA.Model.Achievement> list = bll.DSearch(model);
           
            return PartialView(list);
        }
    }
}
