using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final_Project.Models;

namespace Final_Project.Controllers
{
    [Authorize]
    public class InducteesController : Controller
    {
        private DBContextContainer db = new DBContextContainer();

        // GET: Inductees
        public ActionResult Index()
        {
            return View(db.Inductees.ToList());
        }

        // GET: Inductees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inductee inductee = db.Inductees.Find(id);
            if (inductee == null)
            {
                return HttpNotFound();
            }
            return View(inductee);
        }

        // GET: Inductees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inductees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InducteeId,FirstName,LastName,Website,Bio")] Inductee inductee)
        {
            if (ModelState.IsValid)
            {
                db.Inductees.Add(inductee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inductee);
        }

        // GET: Inductees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inductee inductee = db.Inductees.Find(id);
            if (inductee == null)
            {
                return HttpNotFound();
            }
            return View(inductee);
        }

        // POST: Inductees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InducteeId,FirstName,LastName,Website,Bio")] Inductee inductee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inductee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inductee);
        }

        // GET: Inductees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inductee inductee = db.Inductees.Find(id);
            if (inductee == null)
            {
                return HttpNotFound();
            }
            return View(inductee);
        }

        // POST: Inductees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inductee inductee = db.Inductees.Find(id);
            db.Inductees.Remove(inductee);
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
