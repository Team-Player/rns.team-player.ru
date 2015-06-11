using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegisterNotes.Domain.Entities;

namespace RegisterNotes.WebUI.Models
{
    // Wrap all of the data going to send from the controller to the view in a single view model class
    public class NotesListViewModel
    {
        public IEnumerable<Note> Notes { get; set; }        
        public PagingInfo PagingInfo { get; set; }
        public String CurrentPblc { get; set; }
    }
}