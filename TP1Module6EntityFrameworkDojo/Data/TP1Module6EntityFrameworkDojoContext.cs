using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TP1Module6EntityFrameworkBODojoPart2;

namespace TP1Module6EntityFrameworkDojoPart2.Data
{
    public class TP1Module6EntityFrameworkDojoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TP1Module6EntityFrameworkDojoContext() : base("name=TP1Module6EntityFrameworkDojoContext")
        {
        }
        public System.Data.Entity.DbSet<TP1Module6EntityFrameworkBODojoPart2.Samourai> Samourais { get; set; }

        public System.Data.Entity.DbSet<TP1Module6EntityFrameworkBODojoPart2.Arme> Armes { get; set; }
    }
}
