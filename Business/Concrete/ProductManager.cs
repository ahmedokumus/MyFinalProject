using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    private IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public List<Product> GetAll()
    {
        //İş Kodları
        return _productDal.GetAll();
    }

    public List<Product> GetAllByCategoryId(int categoryId)
    {
        return _productDal.GetAll(p => p.CategoryId == categoryId);
    }

    public List<Product> GetByUnitPrice(decimal min, decimal max)
    {
        return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
    }
}