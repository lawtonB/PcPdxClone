using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using PcPdx.Models;
using Microsoft.Data.Entity;




namespace PcPdx.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SiteUser user)
        {
            db.SiteUsers.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            var thisUser = db.SiteUsers.FirstOrDefault(users => users.UserId == id);
            return View(thisUser);
        }

        [HttpPost]
        public IActionResult Edit(SiteUser user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            var thisUser = db.SiteUsers.FirstOrDefault(users => users.UserId == id);
            return View(thisUser);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisUser = db.SiteUsers.FirstOrDefault(users => users.UserId == id);
            db.SiteUsers.Remove(thisUser);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
