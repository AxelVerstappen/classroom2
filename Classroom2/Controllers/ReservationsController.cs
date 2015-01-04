using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Classroom2.Context;
using Classroom2.Models;
using PagedList;
using PagedList.Mvc;

namespace Classroom2.Controllers
{
    public class ReservationsController : Controller
    {
        private ClassroomContext db = new ClassroomContext();

        // GET: Reservations
        public ActionResult Index(string searchString, int? page, string sortBy)
        {
            ViewBag.SortCourseNameParameter = string.IsNullOrEmpty(sortBy) ? "CourseName desc" : "";
            ViewBag.SortTeacherNameParameter = sortBy == "TeacherName" ? "TeacherName desc" : "TeacherName";

            var reservations = from r in db.Reservations select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                reservations = reservations.Where(r => r.CourseName.Contains(searchString));
            }

            switch (sortBy)
            {
                case "CourseName desc":
                    reservations = reservations.OrderByDescending(r => r.CourseName);
                    break;
                case "TeacherName desc":
                    reservations = reservations.OrderByDescending(r => r.TeacherName);
                    break;
                case "TeacherName":
                    reservations = reservations.OrderBy(r => r.TeacherName);
                    break;
                default:
                    reservations = reservations.OrderBy(r => r.CourseName);
                    break;
            }

            return View(reservations.ToPagedList(page ?? 1, 5));
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            if(!User.Identity.IsAuthenticated)
                return RedirectToAction("Index");
            var viewModel = new ReservationViewModel();
            viewModel.Classrooms = new List<SelectListItem>();
            viewModel.Classrooms.Add(new SelectListItem() { Text = "Selecteer een lokaal" });
            foreach (var classroom in db.Classrooms)
            {
                viewModel.Classrooms.Add(new SelectListItem
                {
                    Text = classroom.Name,
                    Value = classroom.Id.ToString(),
                    Selected = false
                });
            }
            return View(viewModel);
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationViewModel reservation)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index");
            var newReservation = new Reservation();
            newReservation.CourseName = reservation.CourseName;
            newReservation.TeacherName = reservation.TeacherName;
            newReservation.StartTime = reservation.StartTime;
            newReservation.EndTime = reservation.EndTime;
            newReservation.ClassroomId = reservation.SelectedClassroomId;

            db.Reservations.Add(newReservation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ReservationViewModel();
            viewModel.CourseName = reservation.CourseName;
            viewModel.TeacherName = reservation.TeacherName;
            viewModel.StartTime = reservation.StartTime;
            viewModel.EndTime = reservation.EndTime;
            viewModel.SelectedClassroomId = reservation.ClassroomId;

            viewModel.Classrooms = new List<SelectListItem>();
            viewModel.Classrooms.Add(new SelectListItem() { Text = "Selecteer een lokaal" });
            foreach (var classroom in db.Classrooms)
            {

                if (viewModel.SelectedClassroomId == classroom.Id)
                {
                    viewModel.Classrooms.Add(new SelectListItem
                    {
                        Text = classroom.Name,
                        Value = classroom.Id.ToString(),
                        Selected = true
                    });
                }
                else
                {
                    viewModel.Classrooms.Add(new SelectListItem
                    {
                        Text = classroom.Name,
                        Value = classroom.Id.ToString(),
                        Selected = false
                    });
                }
            }

            return View(viewModel);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReservationViewModel reservation, int Id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index");
            if (ModelState.IsValid)
            {
                var newReservation = db.Reservations.Find(Id);
                newReservation.CourseName = reservation.CourseName;
                newReservation.TeacherName = reservation.TeacherName;
                newReservation.StartTime = reservation.StartTime;
                newReservation.EndTime = reservation.EndTime;
                newReservation.ClassroomId = reservation.SelectedClassroomId;

                db.Entry(newReservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index");
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
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
    }
}
