using Core.DataAccess;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetailDto> GetCarDetailDtos(Expression<Func<Product, bool>> filter = null);
        //List<ProductDetailDto> GetCarDetailDtos(bool v);
    }
}
