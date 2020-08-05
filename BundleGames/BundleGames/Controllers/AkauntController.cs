using BundleGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BundleGames.Controllers
{
    public class AkauntController : Controller
    {
        // GET: Akaunt
        public ActionResult Index()
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                return View(db.Korisniks.ToList());
            }

        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Korisnik account)
        {

            if (ModelState.IsValid)
            {
                using(ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.Korisniks.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.Korisnik_Name + " " + "successful registration";
            }
            else
            {
                ViewBag.Message = "Registration failed!";
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Korisnik user)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {

                var usr = db.Korisniks.Single(u => u.Username == user.Username && u.Password == user.Password);
                if (user == null)
                {
                    ViewBag.Errormasage = "USER IS NULL";
                }
                else
                {
                    Session["Id"] = user.Id.ToString();
                    Session["Username"] = user.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                return View();
                    
                
            }
            
        }

        public ActionResult LoggedIn()
        {
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}