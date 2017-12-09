using Netkinetix.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Netkinetix.DataAccessLayer
{
    public class NetkinetixContext: DbContext
    {

            public NetkinetixContext() : base("NetkinetixContext")
            {
            }

            // Entity framework uses this as a reflection to help return the model back
            // Basically connects to DB
            public DbSet<SiteEvent> SiteEvent { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        
    }
}