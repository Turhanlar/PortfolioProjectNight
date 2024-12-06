using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class ProfileController : Controller
    {

        MyPortfolioNightEntities context = new MyPortfolioNightEntities();

        public ActionResult ProfileList()
        {
            var values = context.Profile.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateProfile(int id)
        {
            var value = context.Profile.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProfile(Profile profile)
        {
            var value = context.Profile.Find(profile.Profiled);

            value.Birthdate = profile.Birthdate;
            value.Email = profile.Email;
            value.Phone = profile.Phone;
            value.GitHub = profile.GitHub;
            value.Address = profile.Address;
            value.Title = profile.Title;
            value.Description = profile.Description;
            value.ImageUrl = profile.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("ProfileList");
        }
    }
}