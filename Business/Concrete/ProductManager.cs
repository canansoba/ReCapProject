using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Concrete.InMemory;
using Entities.DTO;
using System.Linq.Expressions;
using Core.Utilities.Results;
using Business.Constants;
using FluentValidation;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Validation;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Performance;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product car)
        {
            _productDal.Add(car);

            return new SuccessResult(Messages.ProductAddes);
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Product car)
        {
            _productDal.Delete(car);
            return new ErrorResult(Messages.ProductDeleted);
        }
        [CacheAspect] //key, value
        public IDataResult<List<Product>> GetAll()
        {
            
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<ProductDetailDto>> GetProductByBrandId(int brandId)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetCarDetailDtos(p => p.BrandId == brandId));
        }

        public IDataResult<List<ProductDetailDto>> GetProductByColorId(int colorId)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetCarDetailDtos(p => p.ColorId == colorId));
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Product> GetProductById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == id));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailDto()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetCarDetailDtos());
        }
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product car)
        {
            if (!(car.Description.Length < 2 && car.DailyPrice <= 0))
            {
                
                return new ErrorResult(Messages.ProductControl);
            }
            else
                _productDal.Update(car);
            return new SuccessResult(Messages.ProductUpdates);

        }
    }
}
