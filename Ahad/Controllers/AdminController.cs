using Ahad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ahad.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        EFDbContext contex =new EFDbContext();
        public AdminController()
        {

        }
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult UnitEdit(int id)
        {

            Unit model =contex.Units.Find(id);
          
            return View(model);
        }

        [HttpPost]
        public ActionResult UnitEdit(Unit model)
        {

            Unit unt = contex.Units.Find(model.UnitId);
            unt.Name = model.Name;
            contex.SaveChanges();
            return RedirectToAction("UnitList");
        }
        public ViewResult UnitList( )
        {

            List<Unit> model; 

            model = contex.Units.ToList();
            return View(model);
        }
        public ViewResult UnitCreate()
        {
            return View();
        }
        public ViewResult NewlyRegisterd()
        {
            List<Useer> model;
            ViewBag.Unit = new SelectList(contex.Units.ToList(), "UnitId", "Name");
            ViewBag.Position = new SelectList(contex.Positions.ToList(), "PositionId", "Name");
            ViewBag.Role = new SelectList(contex.Roles.ToList(), "RoleId", "Name");
            model = contex.Useers.Where(m=>m.Active==false).ToList();
            return View(model);
        }

      
       
        [AllowAnonymous]
        public ActionResult ConfirmNewlyRegisterd(int roleId, int positionId, int unitId, int userId)
        {

            ViewBag.Unit = new SelectList(contex.Units.ToList(), "UnitId", "Name");
            ViewBag.Position = new SelectList(contex.Positions.ToList(), "PositionId", "Name");
            ViewBag.Role = new SelectList(contex.Roles.ToList(), "RoleId", "Name");
            Useer user = contex.Useers.Find(userId);
            user.PositionId = positionId;
            user.RoleId = roleId;
            user.UnitId = unitId;
            user.Active = true;
            contex.SaveChanges();

            return RedirectToAction("NewlyRegisterd");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UnitCreate(Unit model)
        {
       
        if(ModelState.IsValid)
        {
            contex.Units.Add(model);
            contex.SaveChanges();
            return RedirectToAction("UnitList");
        }
        return View(model);
        }

        public ViewResult UnitMonthlyAmount()
        {
            List<Unit> model;
            model = contex.Units.ToList();
            return View(model);
        }

        public ViewResult UnitMonthlyAmountEdit(int id)
        {

            Unit model = contex.Units.Find(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult UnitMonthlyAmounttEdit(Unit model)
        {

            Unit unt = contex.Units.Find(model.UnitId);
            unt.FixedAmount = model.FixedAmount;
            contex.SaveChanges();
            return RedirectToAction("UnitMonthlyAmount");
        }

        [AllowAnonymous]
        
        public ActionResult UnitDelete(int? id)
        {
          Unit model=  contex.Units.Find(id);
          contex.Units.Remove(model);
          contex.SaveChanges();

            return RedirectToAction("UnitList");
        }

        public ViewResult PersonalActivityList()
        {
            List<PersonalActivityList> model = contex.PersonalActivityLists.ToList();
            return View(model);
        }

        public ViewResult ActivityEdit(int id)
        {
            PersonalActivityList model = contex.PersonalActivityLists.Find(id);
            ViewBag.ActivityType = new SelectList(contex.ActivityTypes.ToList(), "TypeId", "Type");

            return View(model);
        }

        [HttpPost]
        public ActionResult ActivityEdit(PersonalActivityList model)
        {

            PersonalActivityList pact = contex.PersonalActivityLists.Find(model.PersonalActivityListId);
            pact.ActivityTitle = model.ActivityTitle;
            pact.TypeId = model.TypeId;
            contex.SaveChanges();
            return RedirectToAction("PersonalActivityList");
        }

        [AllowAnonymous]

        public ActionResult ActivityDelete(int? id)
        {
            PersonalActivityList model = contex.PersonalActivityLists.Find(id);
            contex.PersonalActivityLists.Remove(model);
            contex.SaveChanges();

            return RedirectToAction("PersonalActivityList");
        }

        public ViewResult CreateActivity()
        {
            ViewBag.ActivityType = new SelectList(contex.ActivityTypes.ToList(), "TypeId", "Type");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateActivity(PersonalActivityList model)
        {
            Console.WriteLine(ModelState);
            if (ModelState.IsValid)
            {
                contex.PersonalActivityLists.Add(model);
                contex.SaveChanges();
                return RedirectToAction("PersonalActivityList");
            }
            return View(model);
        }
         
	}
}