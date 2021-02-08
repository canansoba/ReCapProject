using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Concrete.InMemory;
using Entities.DTO;
using System.Linq.Expressions;

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

        public List<ProductDetailDto> GetProductByBrandId(int brandId)
        {
            return _productDal.GetCarDetailDtos(p => p.BrandId == brandId);
        }

        public List<ProductDetailDto> GetProductByColorId(int colorId)
        {
            return _productDal.GetCarDetailDtos(p => p.ColorId == colorId);
        }

        public Product GetProductById(int id)
        {
            return _productDal.Get(p => p.Id == id);
        }

        public List<ProductDetailDto> GetProductDetailDto()
        {
            return _productDal.GetCarDetailDtos();
        }

        public void Update(Product car)
        {
            if (!(car.Description.Length < 2 && car.DailyPrice <= 0))
            {
                _productDal.Update(car);
            }
            else
                Console.WriteLine("Açıklama ve günlük fiyat girişini kontrol ediniz.");
        }

        //List<ProductDetailDto> IProductService.GetProductByBrandId(int brandId)
        //{
        //    throw new NotImplementedException();
        //}

        //List<ProductDetailDto> IProductService.GetProductByColorId(int colorId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
