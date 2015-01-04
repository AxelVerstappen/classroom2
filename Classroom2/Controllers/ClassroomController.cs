using Classroom2.Context;
using Classroom2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Classroom2.Controllers
{
    public class ClassroomController : Controller
    {

        private ClassroomContext db = new ClassroomContext();

        // GET: Classroom
        public ActionResult Index(string searchString, int? page, string sortBy)
        {
            ViewBag.SortNameParameter = string.IsNullOrEmpty(sortBy) ? "Name desc" : "";
            ViewBag.SortPlacesParameter = sortBy == "Places" ? "Places desc" : "Places";

            var classrooms = from c in db.Classrooms select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                classrooms = classrooms.Where(s => s.Name.Contains(searchString));
            }

            switch (sortBy)
            {
                case "Name desc":
                    classrooms = classrooms.OrderByDescending(s => s.Name);
                    break;
                case "Places desc":
                    classrooms = classrooms.OrderByDescending(s => s.Places);
                    break;
                case "Places":
                    classrooms = classrooms.OrderBy(s => s.Places);
                    break;
                default:
                    classrooms = classrooms.OrderBy(s => s.Name);
                    break;
            }

            return View(classrooms.ToPagedList(page ?? 1,5));
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
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index");
            var viewModel = new ClassroomViewModel();
            viewModel.Buildings = new List<SelectListItem>();
            viewModel.Buildings.Add(new SelectListItem() { Text = "Selecteer een gebouw" });
            foreach (var building in db.Buildings)
            {
                viewModel.Buildings.Add(new SelectListItem
                {
                    Text = building.Name,
                    Value = building.Id.ToString(),
                    Selected = false
                });
            }

            return View(viewModel);
        }

        // POST: Classroom/Create
        [HttpPost]
        public ActionResult Create(ClassroomViewModel classroom)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index");
            var newClassroom = new Classroom();
            newClassroom.Name = classroom.Name;
            newClassroom.Places = classroom.Places;
            newClassroom.BuildingId = classroom.SelectedBuildingId;

            db.Classrooms.Add(newClassroom);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Classroom/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index");
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Classroom classroom = db.Classrooms.Find(id);

            if (classroom == null)
                return HttpNotFound();

            var viewModel = new ClassroomViewModel();
            viewModel.SelectedBuildingId = classroom.BuildingId;
            viewModel.Name = classroom.Name;
            viewModel.Places = classroom.Places;

            viewModel.Buildings = new List<SelectListItem>();
            viewModel.Buildings.Add(new SelectListItem() { Text = "Selecteer een gebouw" });
            foreach (var building in db.Buildings)
            {

                if(viewModel.SelectedBuildingId == building.Id) {
                    viewModel.Buildings.Add(new SelectListItem
                    {
                        Text = building.Name,
                        Value = building.Id.ToString(),
                        Selected = true
                    });
                } else {
                    viewModel.Buildings.Add(new SelectListItem
                    {
                        Text = building.Name,
                        Value = building.Id.ToString(),
                        Selected = false
                    });
                }
            }

            return View(viewModel);
        }

        // POST: Classroom/Edit/5
        [HttpPost]
        public ActionResult Edit(ClassroomViewModel classroom, int Id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index");
            var newClassroom = db.Classrooms.Find(Id);
            newClassroom.Name = classroom.Name;
            newClassroom.Places = classroom.Places;
            newClassroom.BuildingId = classroom.SelectedBuildingId;
            db.Entry(newClassroom).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Classroom/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index");
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
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index");
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
