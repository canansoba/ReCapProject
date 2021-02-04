using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
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
            //ProductManager productManager = new ProductManager(new EfProductDal());
            IProductService productService = new ProductManager(new EfProductDal());
            productService.Add(new Product { Id=3,BrandId = 1, ColorId=3, DailyPrice = 500,ModelYear =2020, Description="ASD" });
            productService.Add(new Product
            {
                Id=4,
                BrandId = 2,
                ColorId = 2,
                DailyPrice = 0,
                ModelYear = 1992,
                Description = "a"
            });
            foreach (var car in productService.GetProductByBrandId(1))
            {

                Console.WriteLine("Arabanın Açıklaması: {0} Model Yılı: {1} Günlük Ücreti: {2}", car.Description, car.ModelYear, car.DailyPrice);
               // Console.WriteLine($"{car.Id}. Marka: {car.BrandId}     Fiyat: {car.DailyPrice}     Açıklama: {car.Description}");

            }

            Console.ReadLine();



        }
    }
}
