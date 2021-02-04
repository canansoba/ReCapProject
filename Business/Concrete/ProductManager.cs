using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Concrete.InMemory;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Add(Product car)
        {
            if (!(car.Description.Length < 2 && car.DailyPrice <= 0))
            {
                _productDal.Add(car);
            }
            else
                Console.WriteLine("Açıklama ve günlük fiyat girişini kontrol ediniz.");
        }

        public void Delete(Product car)
        {
            _productDal.Delete(car);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetProductByBrandId(int brandId)
        {
            return _productDal.GetAll(p => p.BrandId == brandId);
        }

        public List<Product> GetProductByColorId(int colorId)
        {
            return _productDal.GetAll(p => p.ColorId == colorId);
        }

        public Product GetProductById(int id)
        {
            return _productDal.Get(p => p.Id == id);
        }

        public void Update(Product car)
        {
            _productDal.Update(car);
        }
    }
}
