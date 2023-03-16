using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    private IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public IDataResult<List<Product>> GetAll()
    {
        //İş Kodları
        if (DateTime.Now.Hour == 12)
        {
            return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
        }
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
    }

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

    public IResult Add(Product product)
    {
        //business codes - iş kodları
        if (product.ProductName.Length < 2)
        {
            //magic strings
            return new ErrorResult(Messages.ProductNameInvalid);
        }
        _productDal.Add(product);
        return new SuccessResult(Messages.ProductAdded);
    }

    public IResult Update(Product product)
    {
        throw new NotImplementedException();
    }

    public IResult Delete(Product product)
    {
        throw new NotImplementedException();
    }
}