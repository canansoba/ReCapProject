using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetProductById(int id);
        List<Product> GetProductByBrandId(int brandId);
        List<Product> GetProductByColorId(int colorId);
        void Add(Product car);
        void Update(Product car);
        void Delete(Product car);
    }
}
