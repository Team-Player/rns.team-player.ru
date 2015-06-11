using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegisterNotes.Domain.Abstract;
using RegisterNotes.Domain.Entities;
using RegisterNotes.WebUI.Models;
using RegisterNotes.WebUI.Filters;

namespace RegisterNotes.WebUI.Controllers
{
    [MUI]
    public class NoteController : Controller
    {
        private INoteRepository repository;

        // Adding Pagination Support to the List Action Method.
        // The PageSize field specifies that I want four products per page.
        public int PageSize = 2;

        public NoteController(INoteRepository noteRepository)
        {
            this.repository = noteRepository;
        }

        // Added an optional parameter to the List method. This means that if call the method without a parameter (List()),
        // call is treated as though had supplied the value specified in the parameter definition (List(1))
        // The effect is that the action method displays the first page of notes when the MVC
        // Framework invokes it without an argument. 
        public ViewResult List(string pblc, int page = 1)
        {
            // Within the body of the action method, the Note objects, order them by the primary key, skip over the products
            // that occur before the start of the current page, and take the number of products specified by the PageSize field.
            NotesListViewModel model = new NotesListViewModel
            {
                Notes = repository.Notes
                    .OrderByDescending(p => p.CreateTime)
                    .Where(p => pblc == null || p.Pblc == pblc)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,

                    // If a category has been selected, return the number of items in that category; if not, return the total number of notes.
                    // Now when view a category, the links at the bottom of the page correctly reflect the number of notes in the category (pblc).                 
                    TotalItems = pblc == null ?
                        repository.Notes.Count() :
                        repository.Notes.Where(e => e.Pblc == pblc).Count()
                },
                CurrentPblc = pblc
            };

            // These data pass a NotesListViewModel object as the model data to the view.
            return View(model);
        }

        public ActionResult Tasks()
        {
            return View();
        }
        
    }
}