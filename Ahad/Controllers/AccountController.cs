using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Ahad.Models;
using System.Web.Security;

namespace Ahad.Controllers
{
 
    public class AccountController : Controller
    {
        EFDbContext contex = new EFDbContext();
        public AccountController()
        {

        }

     
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public  ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Useer user = contex.Useers.Where(m => m.Email == model.UserName)
                                           .Where(m => m.Password == model.Password)
                                           .FirstOrDefault();
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);

                    var authTicket = new FormsAuthenticationTicket(1, user.FirstName, DateTime.Now, DateTime.Now.AddMinutes(20), false, user.Roles.Name);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    return RedirectToLocal("Admin/NewlyRegisterd");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Email or password.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ViewResult Register()
        {
 

            ViewBag.Unit = new SelectList(contex.Units.ToList(), "UnitId", "Name");
            return View();
        }
      
        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Useer model)
        {

            ViewBag.Unit = new SelectList(contex.Units.ToList(), "UnitId", "Name");
            if(ModelState.IsValid)
            {
                model.PositionId = 1;
                model.RoleId = 1;
                model.Active = false;
                contex.Useers.Add(model);
                contex.SaveChanges();
            }
         
            return View(model);
        }


        //
        // POST: /Account/LogOff


        //
        // GET: /Account/ExternalLoginFailure
      

      
    }
}