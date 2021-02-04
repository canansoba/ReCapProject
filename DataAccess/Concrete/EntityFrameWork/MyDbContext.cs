using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using System.Linq;
using System.Linq.Expressions;


namespace DataAccess.Concrete.EntityFrameWork
{
    public class MyDbContext:DbContext
    {
       // var sqlServer = Configuration.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MyDb;Trusted_Connection=true");
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Brand> Brand { get; set; }
    }
}
