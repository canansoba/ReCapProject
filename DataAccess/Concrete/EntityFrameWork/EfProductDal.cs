using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfProductDal : EfEntityRepositoryBase<Product, MyDbContext>, IProductDal

    {
        public List<ProductDetailDto> GetCarDetailDtos(Expression<Func<Product, bool>> filter = null)
        {
            using (MyDbContext context = new MyDbContext())
            {
                var result = from prod in filter is null ? context.Product : context.Product.Where(filter)
                             join joinBrand in context.Brand
                             on prod.BrandId equals joinBrand.Id
                             join joinColor in context.Color
                             on prod.ColorId equals joinColor.Id
                             select new ProductDetailDto
                             {
                                 Id = prod.Id,
                                 BrandId = joinBrand.Id,
                                 ColorId = joinColor.Id,
                                 BrandName = joinBrand.BrandName,
                                 ColorName = joinColor.ColorName,
                                 DailyPrice = prod.DailyPrice,
                                 Description = prod.Description,
                                 ModelYear = prod.ModelYear
                             };

                return result.ToList();
            }
        }
    }
}
