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
        {//-----1------
            //Add();
            //GetBrandId();
            //GetColorId();
            //GetAll();
         //------2------
            // UserCrudOperations();
            //CustomerCrudOperation();
            RentalCrudOperation();

        }

        private static void RentalCrudOperation()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
           // rentalManager.Add(new Rental { CustomerId = 3, RentDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(2) });
            //rentalManager.Add(new Rental { CustomerId = 4, RentDate = DateTime.Now });
           // rentalManager.Add(new Rental { CustomerId = 6, RentDate = DateTime.Now });
           // rentalManager.Add(new Rental { CustomerId = 6, RentDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(2) });
            // bu eklenmemeli
            rentalManager.Add(new Rental { ProductId = 10, CustomerId = 6, RentDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(2) });

            //rentalManager.Add(new Rental { ProductId = 11, CustomerId = 1, RentDate = DateTime.Now });

            var rent = rentalManager.GetById(2).Data;
            rent.ReturnDate = DateTime.Now.AddDays(1);
            rentalManager.Update(rent);

            rentalManager.Add(new Rental { ProductId = 6, CustomerId = 4, RentDate = DateTime.Now.AddDays(5), ReturnDate = DateTime.Now.AddDays(15) });
            foreach (var item in rentalManager.GetAllWithDetails().Data)
            {
                Console.WriteLine($" {"Ürün: "+item.ProductName} {"Kullanıcı: "+item.UserName} {"Marka: "+item.BrandName} " +
                    $"{"Gidiş Tarihi: "+item.RentDate} {"Dönüş Tarihi: "+item.ReturnDate} ");
            }
        }

        private static void CustomerCrudOperation()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { UserId = 4, CompanyName = "TEST SIRKETI" });
            customerManager.Add(new Customer { UserId = 5, CompanyName = "TEST SIRKETI" });
            customerManager.Add(new Customer { UserId = 5, CompanyName = "TEST2 SIRKETI" });
            customerManager.Delete(new Customer { Id = 5 });
            var customer = customerManager.GetById(4).Data;
            customer.CompanyName = "Kimyass";
            customerManager.Update(customer);
            customerManager.Add(new Customer { UserId = 6, CompanyName = "TEST2 SIRKETI" });
        }

        private static void UserCrudOperations()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { FirstName = "Canan", LastName = "Soba", Email = "canansoba@gmail.com", Password = "123" });
            //userManager.Delete(new User { Id=2});
            var user = userManager.GetById(3).Data;
            user.Email = "esra@yahoo.com";
            userManager.Update(user);
        }

       

        private static void GetAll()
        {
            foreach (Product product in _productService.GetAll().Data)
            {
                Console.WriteLine($"Id {product.Id}, Description : {product.Description}");
            }
        }
        private static void Delete()
        {
            _productService.Delete(new Product { Id=1, BrandId = 1, ColorId = 1, DailyPrice = 50000, Description = "mercedes e200", ModelYear = 2005 });
            foreach (var car in _productService.GetAll().Data)
            {
                Console.WriteLine("ıd : " + car.Id + " marka ıd : " + car.BrandId + " renk ıd : " + car.ColorId + " fiyat : " + car.DailyPrice + " araba : " + car.Description + " model yili :  " + car.ModelYear);
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
