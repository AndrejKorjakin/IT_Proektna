using BundleGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
                    var Username = db.Korisniks.Any(x => x.Username == account.Username);
                    if (Username)
                    {
                        ModelState.AddModelError("Username", "User with this Username or Email already exists");
                        return View(account);
                    }else
                    {
                        db.Korisniks.Add(account);
                        db.SaveChanges();
                        ModelState.Clear();
                        ViewBag.Message = account.Korisnik_Name + " " + "successful registration";
                        return RedirectToAction("Login", "Akaunt");
                    } 
                    
                }
                
               
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

                
                var Username = db.Korisniks.Any(x => x.Username == user.Username);
                if (!Username)
                {
                    ViewBag.Errormasage = "USER NOT FOUND!";
                }else
                {
                    var usr = db.Korisniks.Single(u => u.Username == user.Username && u.Password == user.Password);
                    Session["UserId"] = user.Id.ToString();
                    Session["Username"] = user.Username.ToString();
                    return RedirectToAction("Index", "Games");
                }
                if (user == null)
                {
                    ViewBag.Errormasage = "USER IS NULL";
                }
                
                return View();
                    
                
            }
            
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index", "Games");
        }

        
    }
}