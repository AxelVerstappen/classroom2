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
            if(!User.Identity.IsAuthenticated)
                return RedirectToAction("Index");
            return View();
        }

        // POST: Building/Create
        [HttpPost]
        public ActionResult Create(Building building)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index");
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
        public ActionResult Edit(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index");
            if(id==null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var building = db.Buildings.Find(id);
            if (building == null)
                return HttpNotFound();
            
            return View(building);
        }

        // POST: Building/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Building building)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index");
            try
            {
                if(ModelState.IsValid)
                {
                    db.Entry(building).State = EntityState.Modified;
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

        // GET: Building/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index");
            if(id==null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var building = db.Buildings.Find(id);

            if (building == null)
                return HttpNotFound();

            return View(building);
        }

        // POST: Building/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Building building)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index");
            try
            {
                if(ModelState.IsValid)
                {
                    Building b = db.Buildings.Find(id);
                    if (b == null)
                        return HttpNotFound();

                    db.Buildings.Remove(b);
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

        public ActionResult SwitchLanguage(string language)
        {
            Session.Add("taal", language);
            return RedirectToAction("Index");
        }
    }

}
