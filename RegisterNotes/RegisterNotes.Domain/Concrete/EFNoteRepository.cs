using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegisterNotes.Domain.Abstract;
using RegisterNotes.Domain.Entities;

namespace RegisterNotes.Domain.Concrete
{
    // This is the repository class. It implements the IProductRepository interface and uses an instance of
    // EFDbContext to retrieve data from the database using the Entity Framework.    

    public class EFNoteRepository : INoteRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Note> Notes
        {
            get { return context.Notes; }
        }
    }

    // P.S.: To use the new repository class, edit the Ninject bindings and replace the mock repository with
    // a binding for the real one. Edit the NinjectDependencyResolver.cs class file in
    // the RegisterNotes.WebUI project so that the AddBindings method 
}
