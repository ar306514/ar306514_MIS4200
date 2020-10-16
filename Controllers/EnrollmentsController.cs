using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ar306514_MIS4200.DAL;
using ar306514_MIS4200.Models;

namespace ar306514_MIS4200.Controllers
{
    public class EnrollmentsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: Enrollments
        public ActionResult Index()
        {
            var enrollments = db.Enrollments.Include(e => e.Courses).Include(e => e.Students);
            return View(enrollments.ToList());
        }

        // GET: Enrollments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollments enrollments = db.Enrollments.Find(id);
            if (enrollments == null)
            {
                return HttpNotFound();
            }
            return View(enrollments);
        }

        // GET: Enrollments/Create
        public ActionResult Create()
        {
            ViewBag.courseId = new SelectList(db.Courses, "courseId", "description");
            ViewBag.studentId = new SelectList(db.Students, "studentId", "firstName");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "enrollmentId,grade,studentId,courseId")] Enrollments enrollments)
        {
            if (ModelState.IsValid)
            {
                db.Enrollments.Add(enrollments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.courseId = new SelectList(db.Courses, "courseId", "description", enrollments.courseId);
            ViewBag.studentId = new SelectList(db.Students, "studentId", "firstName", enrollments.studentId);
            return View(enrollments);
        }

        // GET: Enrollments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollments enrollments = db.Enrollments.Find(id);
            if (enrollments == null)
            {
                return HttpNotFound();
            }
            ViewBag.courseId = new SelectList(db.Courses, "courseId", "description", enrollments.courseId);
            ViewBag.studentId = new SelectList(db.Students, "studentId", "firstName", enrollments.studentId);
            return View(enrollments);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "enrollmentId,grade,studentId,courseId")] Enrollments enrollments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.courseId = new SelectList(db.Courses, "courseId", "description", enrollments.courseId);
            ViewBag.studentId = new SelectList(db.Students, "studentId", "firstName", enrollments.studentId);
            return View(enrollments);
        }

        // GET: Enrollments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollments enrollments = db.Enrollments.Find(id);
            if (enrollments == null)
            {
                return HttpNotFound();
            }
            return View(enrollments);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrollments enrollments = db.Enrollments.Find(id);
            db.Enrollments.Remove(enrollments);
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
