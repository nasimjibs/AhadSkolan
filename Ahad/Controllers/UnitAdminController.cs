using Ahad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ahad.Controllers
{
    public class UnitAdminController : Controller
    {
        //
        // GET: /UnitAdmin/
        EFDbContext context = new EFDbContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EventCreate([Bind(Prefix = "Item2")] Event    model2)
        {
            model2.UnitId = 17;
            context.Events.Add(model2);
            context.SaveChanges();
            return RedirectToAction("EventList");
        }

        public ActionResult EventList()
        {
            ViewBag.EventCategories = new SelectList(context.EventCategories.ToList(), "EventCategoryId", "Name");
            int categoryId =context.EventCategories.FirstOrDefault().EventCategoryId;
            ViewBag.EventList = new SelectList(context.EventLists.Where(m => m.EventCategoryId == categoryId).ToList(), "EventListId", "Name");
            IEnumerable<Event> model = context.Events.OrderByDescending(m=>m.EventId).ToList();
            Event model2 = new Event();
            model2.EventCategoryId = context.EventCategories.FirstOrDefault().EventCategoryId;
            model2.ParticipantNumber = null;
            var tuple = new Tuple<IEnumerable<Event>, Event>(model, model2);
            return View(tuple);
        }

        public ActionResult EventEdit(int  id)
        {
           Event model = context.Events.Find(id);
            ViewBag.EventCategories = new SelectList(context.EventCategories.ToList(), "EventCategoryId", "Name");
        
            ViewBag.EventList = new SelectList(context.EventLists.ToList(), "EventListId", "Name");

            return View(model);
        }

        public ActionResult EventDelete(int id)
        {
            Event model = context.Events.Find(id);
            context.Events.Remove(model);
            context.SaveChanges();
            return RedirectToAction("EventList");
        }

        [HttpPost]
        public ActionResult EventEdit(Event model)
        {
            ViewBag.EventCategories = new SelectList(context.EventCategories.ToList(), "EventCategoryId", "Name");

            ViewBag.EventList = new SelectList(context.EventLists.ToList(), "EventListId", "Name");
            if (ModelState.IsValid)
            {
                Event evt = context.Events.Find(model.EventId);
                evt.EventCategoryId = model.EventCategoryId;
                evt.EventDate = model.EventDate;
                evt.ParticipantNumber = model.ParticipantNumber;
                evt.EventListId = model.EventListId;
                context.SaveChanges();
                return RedirectToAction("EventList");
            }
            
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult GetEventListByCategoryId(string ctgId)
        {
            if (String.IsNullOrEmpty(ctgId))
            {
                throw new ArgumentNullException("categoryId");
            }
            int id = 0;
            bool isValid = Int32.TryParse(ctgId, out id);
            var states = context.EventLists.Where(m=>m.EventCategoryId== id).ToList();
            var result = (from s in states
                          select new
                          {
                              id = s.EventListId,
                              name = s.Name
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult INameAutoComplite(string term)
        {

            var result = context.Useers
                        .Where(m => m.FirstName.ToLower().Contains(term.ToLower()) || m.LastName.ToLower().Contains(term.ToLower()))
                        .Select(s => new
                        {
                            UserId = s.UserId,
                            FirstName = s.FirstName,
                            LastName = s.LastName,
                        });
          

            return Json(result, JsonRequestBehavior.AllowGet);
        }
     
        public ActionResult CreateBM( )
        {
            ViewBag.PaymentType = new SelectList(context.PaymentTypes.ToList(), "PaymentTypeId", "Type");
            DateTime TodayDate =  DateTime.Now;
            DateTime PreviousMonth = DateTime.Now.AddDays(TodayDate.Day*-1);

            IEnumerable<PersonalBM> model = context.PersonalBMs
                                                             .Where(m => m.InsertedDate <= TodayDate)
                                                             .Where(m => m.InsertedDate > PreviousMonth)
                                                            .OrderByDescending(m => m.UserId).ToList();
            PersonalBM model2 = new PersonalBM();
            
            var tuple = new Tuple<IEnumerable<PersonalBM>, PersonalBM>(model, model2);
            return View(tuple);
        }

        public ActionResult BMList(string date)
        {
            DateTime dt =Convert.ToDateTime(date);
            List<PersonalBM> model = context.PersonalBMs.Where(m => m.PaymentDate.Value.Month == dt.Month ).Where(m=>m.PaymentDate.Value.Year == dt.Year).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateBM([Bind(Prefix = "Item2")] PersonalBM model)
        {
            ViewBag.PaymentType = new SelectList(context.PaymentTypes.ToList(), "PaymentTypeId", "Type");
            model.InsertedDate = DateTime.Now;
            if(ModelState.IsValid)
            {
                context.PersonalBMs.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("CreateBM");
        }

        public ActionResult BMEdit(int id)
        {
            ViewBag.PaymentType = new SelectList(context.PaymentTypes.ToList(), "PaymentTypeId", "Type");
            PersonalBM model = context.PersonalBMs.Where(m=>m.Id == id).FirstOrDefault();
            model.Useers.FirstName +=" "+ model.Useers.LastName; 
            return View(model);
        }
        [HttpPost]
        public ActionResult BMEdit(PersonalBM model)
        {
            ViewBag.PaymentType = new SelectList(context.PaymentTypes.ToList(), "PaymentTypeId", "Type");

        
            if (ModelState.IsValid)
            {
                PersonalBM bm = context.PersonalBMs.Find(model.Id);
                bm.PaymentDate = model.PaymentDate;
                bm.PaymentTypeId = model.PaymentTypeId;
                bm.UserId = model.UserId;
                bm.CollectedAmount = model.CollectedAmount;
                context.SaveChanges();
                return RedirectToAction("CreateBM");
            }

            return View(model);
        }

        public ActionResult BMDelete(int id)
        {
            PersonalBM model = context.PersonalBMs.Find(id);
            context.PersonalBMs.Remove(model);
            context.SaveChanges();
            return RedirectToAction("CreateBM");
        }

        public ActionResult MonthlyEventReport(string dat)
        {
            DateTime Date;
           if(dat==null)
              Date =  DateTime.Now.Date;
            else
               Date = Convert.ToDateTime(dat);

             var model2 = context.Events.Where(m => m.EventDate.Value.Month == Date.Month)
                                        .Where(m => m.EventDate.Value.Year == Date.Year)
                                                 .GroupBy(m => m.EventLists.Name)
                                                .Select(g => new
                                                {
                                                    EventId = g.Count(),
                                                    EventListId = g.Key,
                                                    ParticipantNumber = g.Sum(item => item.ParticipantNumber),                                          
                                                }).ToList();
        List<EventList> model = model2.Select(g => new EventList

                                            {

                                               Name = g.EventListId,
                                               EventListId = g.EventId,
                                               EventCategoryId = g.ParticipantNumber,

                                            }).ToList();
                                                                      
            return View(model);
        }


	}
}