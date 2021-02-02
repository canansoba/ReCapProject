using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        List<Product> GetAll();
        List<Product> GetByID(int id);
    }
}
