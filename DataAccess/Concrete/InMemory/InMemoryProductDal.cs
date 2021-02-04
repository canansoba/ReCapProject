using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Product {Id=1, ColorId=1, BrandId=1, ModelYear=2021, DailyPrice = 15000, Description="E-Serisi - 4 Matic+" },
                new Product {Id=2, ColorId=1, BrandId=2, ModelYear=2020, DailyPrice = 7000, Description="SUV" },
                new Product {Id=3, ColorId=2, BrandId=3, ModelYear=2019, DailyPrice = 3000, Description="E-Serisi - 4 Matic+" }
            };
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.SingleOrDefault(p => p.Id == id);
        }

        public void Add(Product entity)
        {
            _products.Add(entity);
        }

        public void Delete(Product entity)
        {
            Product deleteProduct = _products.SingleOrDefault(p => p.Id == entity.Id);
            _products.Remove(deleteProduct);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            Product updateProduct = _products.SingleOrDefault(p => p.Id == entity.Id);
            updateProduct.BrandId = entity.BrandId;
            updateProduct.ColorId = entity.ColorId;
            updateProduct.DailyPrice = entity.DailyPrice;
            updateProduct.Description = entity.Description;
            updateProduct.ModelYear = entity.ModelYear;
        }
    }
}
