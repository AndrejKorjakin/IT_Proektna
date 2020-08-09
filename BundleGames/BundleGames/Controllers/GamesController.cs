﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BundleGames.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Provider;


namespace BundleGames.Controllers
{
    public class GamesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        

        // GET: Games
        public ActionResult Index()
        {
            return View(db.Games.ToList());
        }
        public ActionResult Wishlist()
        {
            return View(db.Games.ToList());
        }

        
        public ActionResult AddGameToWishlist(int gameid, int userid)
        {
            AddToWishListModel model = new AddToWishListModel();
            model.GameId = gameid;
            model.KorisnikId = userid;
            
            
            return View();
                
        }
        [HttpPost]
        public ActionResult AddGameToWishlist(AddToWishListModel model)
        {
            var user = db.Korisniks.FirstOrDefault(m=>m.Id == model.KorisnikId );
            var game = db.Games.FirstOrDefault(z => z.Id == model.GameId);
            user.Korisnik_Wishlist.Wishlist_Games.Add(game);
            db.SaveChanges();
            return View("ProfileShow","Korisniks", user.Id);
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Game_Name,Game_Image,Game_Cena,Game_Info,Release_Date,Publisher,Developer")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Game_Name,Game_Image,Game_Cena,Game_Info,Release_Date,Publisher,Developer")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {

            Game listing = db.Games.Find(id);
            db.Games.Remove(listing);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        
        


        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
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
