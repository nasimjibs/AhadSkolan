using Ahad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ahad.Controllers
{
    public class PersonalActivityController : Controller
    {
        EFDbContext context = new EFDbContext();

        // GET: Activity

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InputPersonalActivity()
        {
            List<PersonalActivityList> model;
            model = context.PersonalActivityLists.ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult InputPersonalActivity(string []ItemId , string []Item)
        {
            return View();
        }
    }
}