using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using UniversityManagementSystemApp.Areas.Test.Models;
using UniversityManagementSystemApp.Models;


namespace UniversityManagementSystemApp.Areas.Test.Controllers
{
    public class TestController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: /Test/Test/
        public ActionResult Index()
        {
            return View(db.Tests.ToList());
        }

        // GET: /Test/Test/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: /Test/Test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Test/Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Tag")] Models.Test test)
        {
            if (ModelState.IsValid)
            {
                if (test.Tag == "" || test.Tag.IsEmpty() || test.Tag == null)
                {
                    ViewBag.Error = "Empty Tag are not allowed";
                    return View();
                }
                else if (test.Tag.Length >= 13 && test.Tag.Contains(""))
                {
                    test.Tag = test.Tag.Replace(" ", "<br /><span class='divider'></span>");
                    db.Tests.Add(test);
                    db.SaveChanges();
                }
                //return RedirectToAction("Index");
            }

            return View(test);
        }

        // GET: /Test/Test/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            ViewBag.Length = test.Tag.Length;
            return View(test);
        }

        // POST: /Test/Test/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Tag")] Models.Test test)
        {

            if (ModelState.IsValid)
            {
                db.Entry(test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(test);
        }

        // GET: /Test/Test/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: /Test/Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Test test = db.Tests.Find(id);
            db.Tests.Remove(test);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [ValidateInput(false)]

        public JsonResult SaveTag(Models.Test test)
        {
            db.Tests.Add(test);
            if (db.SaveChanges() > 0)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }
    }
}
