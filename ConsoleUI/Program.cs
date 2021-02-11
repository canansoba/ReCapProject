using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace ConsoleUI
{
    class Program
    {
        public static IProductService _productService = new ProductManager(new EfProductDal());
        static void Main(string[] args)
        {

            Add();
            GetBrandId();
            GetColorId();
            GetAll();

        }

        private static void GetAll()
        {
            foreach (Product product in _productService.GetAll().Data)
            {
                Console.WriteLine($"Id {product.Id}, Description : {product.Description}");
            }
        }

        private static void GetColorId()
        {
            List<ProductDetailDto> product = _productService.GetProductByColorId(1).Data;
            foreach (var prod in product)
            {
                Console.WriteLine($"Car Id: {prod.Id}, Car Description: {prod.Description}, Brand Id : {prod.BrandId}");
            }
        }

        private static void GetBrandId()
        {
            List<ProductDetailDto> product = _productService.GetProductByBrandId(3).Data;
            foreach (var prod in product)
            {
                Console.WriteLine($"Car Id: {prod.Id}, Car Description: {prod.Description}, Brand Id : {prod.BrandId}");
            }
        }

        private static void Add()
        {
           
            Product car1 = new Product
            {
                BrandId = 3,
                ColorId = 2,
                DailyPrice = 10,
                Description = "Mercedes",
                ModelYear = 2015,

            };
            _productService.Add(car1);

            Product car2 = new Product
            {
                BrandId = 2,
                ColorId = 1,
                DailyPrice = 100,
                Description = "Subaru",
                ModelYear = 2020,

            };
            _productService.Add(car2);
        }

        //private static void ProductTest()
        //{
        //    IProductService productService = new ProductManager(new EfProductDal());
        //    productService.Add(new Product { BrandId = 1, ColorId = 3, DailyPrice = 500, ModelYear = 2020, Description = "ASD" });
        //    productService.Add(new Product
        //    {

        //        BrandId = 2,
        //        ColorId = 2,
        //        DailyPrice = 0,
        //        ModelYear = 1992,
        //        Description = "a"
        //    });
        //    foreach (var car in productService.GetProductByBrandId(1))
        //    {

        //        Console.WriteLine("Arabanın Açıklaması: {0} Model Yılı: {1} Günlük Ücreti: {2}", car.Description, car.ModelYear, car.DailyPrice);
        //        // Console.WriteLine($"{car.Id}. Marka: {car.BrandId}     Fiyat: {car.DailyPrice}     Açıklama: {car.Description}");

        //    }
        //}
    }
}
