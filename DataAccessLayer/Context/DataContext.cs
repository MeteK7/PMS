using BusinessObjectsLayer;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataContext
{
    public class DataContext:DbContext
    {
        /*The name of the connection string is passed into the constructor.
        This name will be used in web.config file.*/
        public DataContext() : base("name=DataContext") { }

        public virtual DbSet<User> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}
