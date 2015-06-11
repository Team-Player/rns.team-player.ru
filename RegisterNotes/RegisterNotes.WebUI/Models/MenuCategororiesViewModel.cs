using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegisterNotes.WebUI.Models
{
    // Wrap all of the data going to send from the controller to the view in a single view model class

    public class MenuCategororiesViewModel
    {
        public string[] categories = new string[3] { "All", "Public", "Private" };
    }
}