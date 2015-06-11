using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegisterNotes.WebUI.Infrastructure.Abstract;
using RegisterNotes.WebUI.Models;
using RegisterNotes.WebUI.Filters;

namespace RegisterNotes.WebUI.Controllers
{
    [MUI]
    public class AccountController : Controller
    {
        IAuthProvider authProvider;
        
        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }

        public ViewResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("List", "Note"));
                }
                else
                {
                    ModelState.AddModelError("", "Не верное имя пользователя или пароль");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            // AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}