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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        // public DbSet<Order> Order { get; set; }
    }
}
