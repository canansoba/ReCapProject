using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        List<Product> GetAll();
        List<Product> GetByID();
    }
}
