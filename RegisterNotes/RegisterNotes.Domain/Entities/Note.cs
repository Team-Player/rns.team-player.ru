using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterNotes.Domain.Entities
{
    public class Note
    {
        // Defining domain model in a separate Visual Studio project, which means that the class must be marked as public.
        // Do not need to follow this convention, but that it helps keep the model separate from the controllers.

        public int ID { get; set; }
        public int UserId { get; set; }
        public DateTime CreateTime { get; set; }
        public string Pblc { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
