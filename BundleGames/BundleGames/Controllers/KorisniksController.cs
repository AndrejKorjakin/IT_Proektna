using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BundleGames.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;


namespace BundleGames.Controllers
{
    public class KorisniksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        

        // GET: Korisniks
        public ActionResult Index()
        {
           
            return View(db.Korisniks.ToList());
        }

        public ActionResult MakeAdmin(int? id)
        {
            if (id != null)
            {
                db.Korisniks.Find(id).IsAdmin = 1;
                return View();
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult ProfileShow(int? id)
        {
            var korisnik = db.Korisniks.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }else 
            {
                
                if (korisnik == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }else
                {
                    ViewBag.Username = korisnik.Username;
                    
                    return View(korisnik);
                }
                
            }
            


            
        }

        
        // GET: Korisniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = db.Korisniks.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // GET: Korisniks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Korisniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Korisnik_Name,Username,Password,Image,Age")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                db.Korisniks.Add(korisnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(korisnik);
        }

        // GET: Korisniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = db.Korisniks.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // POST: Korisniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Korisnik_Name,Username,Password,Image,Age")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(korisnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(korisnik);
        }
        public ActionResult WishListDelete(int? id)
        {
            //Treba da se izbrishe igrata od wishlist na korisnikot
            Game game = new Game();
            game.Id = 8;
            
            
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Korisniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = db.Korisniks.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // POST: Korisniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Korisnik korisnik = db.Korisniks.Find(id);
            db.Korisniks.Remove(korisnik);
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
