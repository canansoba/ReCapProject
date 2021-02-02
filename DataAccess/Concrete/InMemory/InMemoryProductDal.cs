using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product {ProductId=1, ColorId=1, BrandId=1, ModelYear=2021, DailyPrice = "3580000", Description="E-Serisi - 4 Matic+" },
                new Product {ProductId=2, ColorId=1, BrandId=2, ModelYear=2020, DailyPrice = "555000", Description="SUV" },
                new Product {ProductId=3, ColorId=2, BrandId=3, ModelYear=2019, DailyPrice = "493400", Description="E-Serisi - 4 Matic+" }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product); 
        }

        public void Delete(int id)
        {
            //Product productToDelete = _products.SingleOrDefault(p => p.ProductId == id);
            //_products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetByID(int id)
        {
            return _products.Where(p => p.ProductId == id).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.BrandId = product.BrandId;
            productToUpdate.ColorId = product.ColorId;
            productToUpdate.DailyPrice = product.DailyPrice;
            productToUpdate.Description = product.Description;
            productToUpdate.ModelYear = product.ModelYear;
        }
    }
}
