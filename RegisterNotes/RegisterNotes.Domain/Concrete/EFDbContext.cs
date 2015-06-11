using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegisterNotes.Domain.Entities;
using System.Data.Entity;

namespace RegisterNotes.Domain.Concrete
{
    // Create a context class that will associate the model with the database

    public class EFDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
    }

    // P.S.: To take advantage of the code-first feature, need to create a class that is derived from System.Data.Entity.
    // DbContext. This class then automatically defines a property for each table in the database that to work with.
    // The name of the property specifies the table, and the type parameter of the DbSet result specifies the model type
    // that the Entity Framework should use to represent rows in that table. In this case, the property name is Notes and
    // the type parameter is Note, meaning that the Entity Framework should use the Note model type to represent
    // rows in the Notes table.
    
    // P.S.S.: Need to tell the Entity Framework how to connect to the database, which I do by adding a database
    // connection string to the Web.config file in the RegisterNotes.WebUI project with the same name as the context class
}
