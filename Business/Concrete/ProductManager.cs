using Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using DataAccess.Abstract;
using Entities.DTOs;
using Core.Utilities.Results;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal; //Injection

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //business codes - iş kodları
            _productDal.Add(product);

            return new Result(true);
        }

        public List<Product> GetAll()
        {
            //İş kodları
            //Yetkisi var mı?
            return _productDal.GetAll();
        }

        public List<Product> GetAllCategoryId(int id)
        {
            return _productDal.GetAll(x => x.CategoryId == id);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public List<Product> GetByUnitePrice(decimal min, decimal max)
        {
            return _productDal.GetAll(x => x.UnitPrice >= min && x.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}