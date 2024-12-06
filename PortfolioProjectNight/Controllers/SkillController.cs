using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.Web.Helpers;
using PagedList;
using PagedList.Mvc;


namespace PortfolioProjectNight.Controllers
{
    public class SkillController : Controller
    {

        MyPortfolioNightEntities context = new MyPortfolioNightEntities();

        public ActionResult SkillList(int page = 1)
        {
            var values = context.Skill.ToList().ToPagedList(page, 5);
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSkill(Skill skill)
        {
            context.Skill.Add(skill);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public ActionResult DeleteSkill(int id)
        {
            var value = context.Skill.Find(id);
            context.Skill.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var value = context.Skill.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSkill(Skill skill)
        {
            var value = context.Skill.Find(skill.Skillid);
            value.SkillName = skill.SkillName;
            value.Rate = skill.Rate;
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public ActionResult SkillStatisticGraphic2()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var veriler = context.Skill.ToList();
            veriler.ToList().ForEach(x => xvalue.Add(x.SkillName));
            veriler.ToList().ForEach(y => yvalue.Add(y.Rate));
            var graphic = new Chart(width: 2000, height: 1000).AddTitle("Yetenekler").AddSeries(chartType: "Column", name: "Yetenek", xValue: xvalue, yValues: yvalue);
            return File(graphic.ToWebImage().GetBytes(), "image/jpeg");
        }

    }
}