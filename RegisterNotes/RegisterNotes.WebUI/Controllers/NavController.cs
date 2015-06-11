using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegisterNotes.Domain.Abstract;
using RegisterNotes.WebUI.Models;
using RegisterNotes.WebUI.Filters;

namespace RegisterNotes.WebUI.Controllers
{
    public class NavController : Controller
    {
        private INoteRepository repository;

        public NavController(INoteRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult _Menu(string pblc = null)
        {
            ViewBag.SelectedPblc = pblc;

            IEnumerable<string> pblcs = repository.Notes 
                .Select(x => x.Pblc)
                .Distinct()
                .OrderBy(x => x);

            return PartialView(pblcs);
        }
    }
}