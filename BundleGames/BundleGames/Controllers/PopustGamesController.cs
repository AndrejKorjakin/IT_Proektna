using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BundleGames.Models;

namespace BundleGames.Controllers
{
    public class PopustGamesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PopustGames
        public ActionResult Index()
        {
            return View(db.PopustGames.ToList());
        }

        // GET: PopustGames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopustGames popustGames = db.PopustGames.Find(id);
            if (popustGames == null)
            {
                return HttpNotFound();
            }
            return View(popustGames);
        }

        // GET: PopustGames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PopustGames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NovaCena,PopustGame")] PopustGames popustGames)
        {
            if (ModelState.IsValid)
            {
                db.PopustGames.Add(popustGames);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(popustGames);
        }

        // GET: PopustGames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopustGames popustGames = db.PopustGames.Find(id);
            if (popustGames == null)
            {
                return HttpNotFound();
            }
            return View(popustGames);
        }

        // POST: PopustGames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NovaCena,PopustGame")] PopustGames popustGames)
        {
            if (ModelState.IsValid)
            {
                db.Entry(popustGames).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(popustGames);
        }

        // GET: PopustGames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopustGames popustGames = db.PopustGames.Find(id);
            if (popustGames == null)
            {
                return HttpNotFound();
            }
            return View(popustGames);
        }

        // POST: PopustGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PopustGames popustGames = db.PopustGames.Find(id);
            db.PopustGames.Remove(popustGames);
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
