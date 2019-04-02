using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteCoder.Common.DataPersistence
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {

        }

        //for each model that needs persisting to the database we need a 
        //corresponding DbSet line like this
        //public DbSet<Model> Models { get; set; }

    }
}
