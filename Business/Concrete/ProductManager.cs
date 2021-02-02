using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Concrete.InMemory;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        IBrandDal _brandDal;
        IColorDal _colorDal;

        public ProductManager(IProductDal productDal, IBrandDal brandDal, IColorDal colorDal)
        {
            _productDal = productDal;
            _brandDal = brandDal;
            _colorDal = colorDal;
        }
        public void Add(Product product)
        {
            int yaz;
            _productDal.Add(product);
            yaz = product.ProductId;
            Console.WriteLine(yaz + " "+"Numaralı ürün eklendi");
        }

        public void Delete(int id)
        {
            _productDal.Delete(id);
            //_productDal.Delete(id);
            //Console.WriteLine(id+" "+ "numaralı araç silindi");
            //int sil;
            //_productDal.Delete(product);
            //sil = product.ProductId;
            //Console.WriteLine(sil +" "+ "Numaralı ürün silindi");
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetByID()
        {
            return _productDal.GetAll();
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
            Console.WriteLine("ürün güncellendi");
        }
    }
}
