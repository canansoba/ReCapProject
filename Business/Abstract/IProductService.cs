using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetProductById(int id);
        List<ProductDetailDto> GetProductByBrandId(int brandId);
        List<ProductDetailDto> GetProductByColorId(int colorId);
        List<ProductDetailDto> GetProductDetailDto();
        void Add(Product car);
        void Update(Product car);
        void Delete(Product car);
    }
}
