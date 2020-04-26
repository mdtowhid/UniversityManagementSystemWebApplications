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
    public class LogInAsStudentController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        public ActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public JsonResult SignUpJson(LogInAsStudent logInAsStudent)
        {
            int rowEffected = 0;
            if (ModelState.IsValid)
            {
                var student =
                    db.Students.FirstOrDefault(
                        x => x.Email == logInAsStudent.Email);
                if (student != null)
                {
                    logInAsStudent.StudentRegistrationNumber = student.StudentRegNo;
                    logInAsStudent.Email = student.Email;
                    logInAsStudent.StudentId = student.Id;
                }
                db.LogInAsStudents.Add(logInAsStudent);
                rowEffected = db.SaveChanges();
                if (rowEffected > 0)
                    return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

    }
}
