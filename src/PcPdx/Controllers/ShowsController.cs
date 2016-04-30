using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using PcPdx.Models;
using Microsoft.Data.Entity;



namespace PcPdx.Controllers
{
    public class ShowsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View(db.Shows.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Show show)
        {
            db.Shows.Add(show);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            var thisShow = db.Shows.FirstOrDefault(shows => shows.ShowId == id);
            return View(thisShow);
        }

        [HttpPost]
        public IActionResult Edit(Show show)
        {
            db.Entry(show).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            var thisShow = db.Shows.FirstOrDefault(shows => shows.ShowId == id);
            return View(thisShow);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisShow = db.Shows.FirstOrDefault(shows => shows.ShowId == id);
            db.Shows.Remove(thisShow);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
