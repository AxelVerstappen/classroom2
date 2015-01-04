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
        public ActionResult Index()
        {
            return View(db.Classrooms.ToList());
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
            var view = new ClassroomViewModel();
            view.Buildings = new List<SelectListItem>();
            //view.Buildings.Add(new SelectListItem() { Text = "Selecteer een gebouw" });

            foreach (var building in db.Buildings)
            {
                view.Buildings.Add(new SelectListItem
                {
                    Text = building.Name,
                    Value = building.Id.ToString(),
                    Selected = false
                });
            }

            return View(view);
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
