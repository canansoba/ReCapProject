using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        void Add(Brand brand);
        void Update(Brand car);
        void Delete(Brand id);
        List<Brand> GetAll();
        List<Brand> GetByID();
    }
}
