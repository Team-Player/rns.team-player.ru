using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegisterNotes.WebUI.Models;
using RegisterNotes.WebUI.Filters;
using RegisterNotes.WebUI.Entities;

namespace RegisterNotes.WebUI.Controllers
{
    public class CultureController : Controller
    {
        public ActionResult ChangeLanguage(string returnUrl, string lang)
        {
            new MultilingualUI().SetLanguage(lang);
            return RedirectToLocal(returnUrl);
            // return RedirectToAction("List", "Note");            
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("List", "Note");
        }
    }
}