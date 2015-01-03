using Classroom2.Context;
using Classroom2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Classroom2.Controllers
{
    public class ClassroomController : Controller
    {

        private ClassroomContext db = new ClassroomContext();

        // GET: Classroom
        public ActionResult Index(string searchString)
        {
            var classrooms = from c in db.Classrooms select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                classrooms = classrooms.Where(s => s.Name.Contains(searchString));
            } 

            return View(classrooms);
        }

        // GET: Classroom/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Classroom classroom = db.Classrooms.Find(id);
            if (classroom == null)
                return HttpNotFound();

            return View(classroom);
        }

        // GET: Classroom/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Classroom/Create
        [HttpPost]
        public ActionResult Create(Classroom classroom)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Classrooms.Add(classroom);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(classroom);

            }
            catch
            {
                return View();
            }
        }

        // GET: Classroom/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Classroom classroom = db.Classrooms.Find(id);
            if (classroom == null)
                return HttpNotFound();

            return View(classroom);
        }

        // POST: Classroom/Edit/5
        [HttpPost]
        public ActionResult Edit(Classroom classroom)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(classroom).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(classroom);
            }
            catch
            {
                return View();
            }
        }

        // GET: Classroom/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Classroom classroom = db.Classrooms.Find(id);

            if (classroom == null)
                return HttpNotFound();

            return View(classroom);
        }

        // POST: Classroom/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Classroom clas)
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                Classroom classroom = db.Classrooms.Find(id);
                if (classroom == null)
                    return HttpNotFound();

                db.Classrooms.Remove(classroom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
