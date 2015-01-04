using Classroom2.Context;
using Classroom2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Classroom2.Controllers
{
    public class BuildingController : Controller
    {

        ClassroomContext db = new ClassroomContext();

        // GET: Building
        public ActionResult Index()
        {
            return View(db.Buildings.ToList());
        }

        // GET: Building/Details/5
        public ActionResult Details(int? id)
        {
            if(id==null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var building = db.Buildings.Find(id);
            
            if(building==null)
                return HttpNotFound();
            
            return View(building);
        }

        // GET: Building/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Building/Create
        [HttpPost]
        public ActionResult Create(Building building)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Buildings.Add(building);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(building);
            }
            catch
            {
                return View();
            }
        }

        // GET: Building/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Building/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Building/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Building/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
