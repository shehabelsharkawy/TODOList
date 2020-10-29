using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOList.Entities.Models;

namespace TODOList.Entities
{

    public class TODOListEntities : DbContext
    {

        public TODOListEntities()
            : base("name=TODOListEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public virtual DbSet<Todo> Todo { get; set; }
       
    }
}
