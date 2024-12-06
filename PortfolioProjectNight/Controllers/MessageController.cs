using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class MessageController : Controller
    {
        MyPortfolioNightEntities context = new MyPortfolioNightEntities();
        public ActionResult Inbox()
        {
            var values = context.Contact.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult MessageDetails(int id)
        {
            var values = context.Contact.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult MessageDetails(Contact contact)
        {
            var values = context.Contact.Find(contact.Contactid);
            values.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public ActionResult DeleteMessage(int id)
        {
            var values = context.Contact.Find(id);
            context.Contact.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public ActionResult ChangeMessageStatusToTrue(int id)
        {
            var value = context.Contact.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public ActionResult ChangeMessageStatusToFalse(int id)
        {
            var value = context.Contact.Find(id);
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

    }
}