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
    public class GamesInShoppingCartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GamesInShoppingCarts
        public ActionResult Index()
        {
            var gamesInShoppingCarts = db.GamesInShoppingCarts.Include(g => g.Game).Include(g => g.Korisnik);
            return View(gamesInShoppingCarts.ToList());
        }

        // GET: GamesInShoppingCarts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamesInShoppingCart gamesInShoppingCart = db.GamesInShoppingCarts.Find(id);
            if (gamesInShoppingCart == null)
            {
                return HttpNotFound();
            }
            return View(gamesInShoppingCart);
        }

        // GET: GamesInShoppingCarts/Create
        public ActionResult Create()
        {
            ViewBag.GameId = new SelectList(db.Games, "Id", "Game_Name");
            ViewBag.KorisnikId = new SelectList(db.Korisniks, "Id", "Korisnik_Name");
            return View();
        }

        // POST: GamesInShoppingCarts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GameId,KorisnikId")] GamesInShoppingCart gamesInShoppingCart)
        {
            if (ModelState.IsValid)
            {
                db.GamesInShoppingCarts.Add(gamesInShoppingCart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameId = new SelectList(db.Games, "Id", "Game_Name", gamesInShoppingCart.GameId);
            ViewBag.KorisnikId = new SelectList(db.Korisniks, "Id", "Korisnik_Name", gamesInShoppingCart.KorisnikId);
            return View(gamesInShoppingCart);
        }

        // GET: GamesInShoppingCarts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamesInShoppingCart gamesInShoppingCart = db.GamesInShoppingCarts.Find(id);
            if (gamesInShoppingCart == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameId = new SelectList(db.Games, "Id", "Game_Name", gamesInShoppingCart.GameId);
            ViewBag.KorisnikId = new SelectList(db.Korisniks, "Id", "Korisnik_Name", gamesInShoppingCart.KorisnikId);
            return View(gamesInShoppingCart);
        }

        // POST: GamesInShoppingCarts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GameId,KorisnikId")] GamesInShoppingCart gamesInShoppingCart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gamesInShoppingCart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameId = new SelectList(db.Games, "Id", "Game_Name", gamesInShoppingCart.GameId);
            ViewBag.KorisnikId = new SelectList(db.Korisniks, "Id", "Korisnik_Name", gamesInShoppingCart.KorisnikId);
            return View(gamesInShoppingCart);
        }

        // GET: GamesInShoppingCarts/Delete/5
        public ActionResult Delete(int? id)
        {

            var userid = int.Parse(Session["UserId"].ToString());
            GamesInShoppingCart game = db.GamesInShoppingCarts.FirstOrDefault(x => x.GameId == id && x.KorisnikId == userid);
            db.GamesInShoppingCarts.Remove(game);
            db.SaveChanges();
            return new EmptyResult();
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
