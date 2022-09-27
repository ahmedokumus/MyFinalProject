using System;
using Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using DataAccess.Abstract;
using Entities.DTOs;
using Core.Utilities.Results;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal; //Injection

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        //AOP
        //[LogAspect] --> 
        //[Validate]// --> Ürün eklenecek kuralları doğrula demek
        //[Transaction] --> Hata olursa geri al
        //[Performance] --> Örneğin çalışma 5 saniyeyi geçerse beni uyar

        [ValidationAspect(typeof(ProductValidator))]//validation codes - doğrulama kodları
        public IResult Add(Product product)
        {
            //business codes - iş kodları

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x => x.CategoryId == categoryId));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitePrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(
                _productDal.GetAll(x => x.UnitPrice >= min && x.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}