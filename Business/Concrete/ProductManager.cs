﻿using System.Transactions;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.TransactionScopeAspect;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    private IProductDal _productDal;
    private ICategoryService _categoryService;

    public ProductManager(IProductDal productDal, ICategoryService categoryService)
    {
        _productDal = productDal;
        _categoryService = categoryService;
    }

    [CacheAspect] //key, value
    [PerformanceAspect(1)]//Methodun çalışması 1 saniyeden uzun sürerse beni bilgilendir
    public IDataResult<List<Product>> GetAll()
    {
        //İş Kodları
        if (DateTime.Now.Hour == 12)
        {
            return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
        }
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
    }

    [CacheAspect]
    public IDataResult<Product> GetById(int productId)
    {
        return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
    }

    public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId));
    }

    public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
    }

    public IDataResult<List<ProductDetailDto>> GetProductDetails()
    {
        if (DateTime.Now.Hour == 1)
        {
            return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
        }
        return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
    }

    //[SecuredOperation("product.add,admin")]
    [ValidationAspect(typeof(ProductValidator))] // validation - doğrulama
    public IResult Add(Product product)
    {
        //business codes - iş kodları

        //IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
        //    CheckIfProductNameExists(product.ProductName), CheckIfCategoryLimitExceded());

        IResult result = BusinessRules.Run(logics: new[]
        {
            CheckIfProductCountOfCategoryCorrect(product.CategoryId),
            CheckIfProductNameExists(product.ProductName),
            CheckIfCategoryLimitExceded()
        });

        if (result != null)
        {
            return result;
        }

        _productDal.Add(product);

        return new SuccessResult(Messages.ProductAdded);
    }

    [CacheRemoveAspect("IProductService.Get")]
    public IResult Update(Product product)
    {
        _productDal.Update(product);

        return new SuccessResult(Messages.ProductUpdated);
    }

    [CacheRemoveAspect("IProductService.Get")]
    public IResult Delete(Product product)
    {
        _productDal.Delete(product);

        return new SuccessResult(Messages.ProductDeleted);
    }

    [PerformanceAspect(1000)]
    [TransactionScopeAspect]
    public IResult AddTransactionalTest(Product product)
    {
        Add(product);
        if (product.UnitPrice < 10)
        {
            throw new Exception("Fırlat");
        }
        Add(product);

        return null;
    }

    private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
    {
        //Select count(*) from products where categoryId=örn 1
        var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
        if (result >= 10)
        {
            return new ErrorResult(Messages.ProductCountCategoryError);
        }
        return new SuccessResult();
    }

    private IResult CheckIfProductNameExists(string productName)
    {
        //Any : ilgili sorgu içerisinde şarta uyan data var mı yok mu
        var result = _productDal.GetAll(p => p.ProductName == productName).Any();
        if (result)
        {
            return new ErrorResult(Messages.ProductNameAlreadyExists);
        }
        return new SuccessResult();
    }

    private IResult CheckIfCategoryLimitExceded()
    {
        var result = _categoryService.GetAll();
        if (result.Data.Count>15)
        {
            return new ErrorResult(Messages.CategoryLimitExceded);
        }
        return new SuccessResult();
    }
}