﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Http.Internal;
using PcPdx.Models;
using Microsoft.Data.Entity;
using System.Diagnostics;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Authorization;
using System.Security.Claims;

namespace PcPdx.Controllers
{
    public class ShowsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ShowsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Shows.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Show show)
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            show.User = currentUser;
            _db.Shows.Add(show);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            var thisShow = _db.Shows.FirstOrDefault(shows => shows.ShowId == id);
            return View(thisShow);
        }

        [HttpPost]
        public IActionResult Edit(Show show)
        {
            _db.Entry(show).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            var thisShow = _db.Shows.FirstOrDefault(shows => shows.ShowId == id);
            return View(thisShow);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisShow = _db.Shows.FirstOrDefault(shows => shows.ShowId == id);
            _db.Shows.Remove(thisShow);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
