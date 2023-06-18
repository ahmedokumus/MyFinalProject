using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface IProductService : IServiceBase<Product>
{
    IDataResult<List<Product>> GetAll();
    IDataResult<Product?> GetById(int productId);
    IDataResult<List<Product>> GetAllByCategoryId(int categoryId);
    IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
    IDataResult<List<ProductDetailDto>> GetProductDetails();
    IResult AddTransactionalTest(Product product);
}