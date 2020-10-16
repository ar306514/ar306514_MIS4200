using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ar306514_MIS4200.Models; // This is needed to access the models
using System.Data.Entity; // this is needed to access the DbContext object

namespace ar306514_MIS4200.DAL
{
  
        public class MIS4200Context : DbContext // inherits from DbContext
        {
            public MIS4200Context() : base("name=DefaultConnection")
            {
                // this method is a 'constructor' and is called when a new context is created
                // the base attribute says which connection string to use
            }
            // Include each object here. The value inside <> is the name of the class,
            // the value outside should generally be the plural of the class name
            // and is the name used to reference the entity in code
            public DbSet<Students> Students { get; set; }
            public DbSet<Courses> Courses { get; set; }
            public DbSet<Enrollments> Enrollments { get; set; }

        }

    }
