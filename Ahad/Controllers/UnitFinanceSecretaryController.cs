using Ahad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Ahad.Controllers
{
    public class UnitFinanceSecretaryController : Controller
    {
        EFDbContext context = new EFDbContext();
        // GET: UnitFinanceSecretary

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InputBM()
        {
            ViewBag.PaymentType = new SelectList(context.PaymentTypes.ToList(), "PaymentTypeId", "Type");

            return View();
        }
    }
}