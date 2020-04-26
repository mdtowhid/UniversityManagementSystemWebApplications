using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Controllers
{
    public class HomeController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HomePageForStudent()
        {
            return View();
        }

        public ActionResult HomePageForAdmin()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        public JsonResult LogInStudent(LogInAsStudent logInAsStudent)
        {
            var student =
                db.LogInAsStudents.FirstOrDefault(
                    x =>
                        x.Email == logInAsStudent.Email &&
                        x.Password == logInAsStudent.Password);
            if (student != null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }

        public JsonResult LogInAdmin(Admin admin)
        {
            var checkAdmin =
                db.Admins.FirstOrDefault(
                    x =>
                        x.Email == admin.Email &&
                        x.Password == admin.Password);
            if (checkAdmin != null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }
    }
}
