using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace ConsoleUI
{
    class Program
    {
       
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal(),new InMemoryBrandDal(),new InMemoryColorDal());
            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());
            ColorManager colorManager = new ColorManager(new InMemoryColorDal());

            Product product1 = new Product { BrandId = 1, ColorId = 1, ProductId = 1, DailyPrice = "50000", Description = "Subaru" };
            Product product2 = new Product { BrandId = 2, ColorId = 1, ProductId = 3, DailyPrice = "5556000", Description = "Mercedes" };
            Product product3 = new Product { ProductId = 2, ColorId = 1, BrandId = 1,  DailyPrice = "3580000", Description = "E-Serisi - 4 Matic+" };

            productManager.Add(product1);
            Console.WriteLine("---Eklendi-----");
            productManager.Update(product2);
            Console.WriteLine("---Güncellendi-----");
            
            productManager.Delete(1);
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.Description);
            }
            Console.WriteLine("----Listelendi----");


        }
    }
}
