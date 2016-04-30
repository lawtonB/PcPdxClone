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

namespace PcPdx.Controllers
{
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public RolesController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public IActionResult Index()
        {
            var roles = _db.Roles.ToList();
            return View(roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string RoleName)
        {
            try
            {
                _db.Roles.Add(new IdentityRole()
                {
                    Name = RoleName
                });
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
        public ActionResult Delete(string Rolename)
        {
            var thisRole = _db.Roles.Where(r => r.Name.Equals(Rolename, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            _db.Roles.Remove(thisRole);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ManageUserRoles()
        {
            var list = _db.Roles.OrderBy(x => x.Name).ToList().Select(xx => new SelectListItem { Value = xx.Name.ToString(), Text = xx.Name }).ToList();
            ViewBag.Roles = list;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RoleAddToUser(string UserName, string RoleName)
        {
            //Async method requires Task which means that await is required on result

            ApplicationUser user = _db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var result = await _userManager.AddToRoleAsync(user, RoleName);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user = _db.Users
                   .Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                ViewBag.RolesForThisUser = _userManager.GetRolesAsync(user).Result;

                var list = _db.Roles
                    .OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();

                ViewBag.Roles = list;

            }
            return View("ManageUserRoles");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRoleForUser(string UserName, string RoleName)
        {

            ApplicationUser user = _db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            if (_userManager.IsInRoleAsync(user, RoleName).Result)
            {
                var result = await _userManager.RemoveFromRoleAsync(user, RoleName);
                ViewBag.ResultMessage = "Role removed from this user successfully !";
            }
            else
            {
                ViewBag.ResultMessage = "This user doesn't belong to selected role.";
            }
            // prepopulat roles for the view dropdown
            var list = _db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            return RedirectToAction("ManageUserRoles");
        }
    }
}
