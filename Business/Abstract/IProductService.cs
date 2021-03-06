using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<Product> GetProductById(int id);
        IDataResult<List<ProductDetailDto>> GetProductByBrandId(int brandId);//ProductDetailDto
        IDataResult<List<ProductDetailDto>> GetProductByColorId(int colorId);//ProductDetailDto
        IDataResult<List<ProductDetailDto>> GetProductDetailDto();//ProductDetailDto
        IResult Add(Product car);
        IResult Update(Product car);
        IResult Delete(Product car);
        IResult AddTransactionalTest(Product product);
    }
}
