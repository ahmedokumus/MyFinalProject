using Entities.Concrete;
using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllCategoryId(int id);
        List<Product> GetByUnitePrice(decimal min, decimal max);
        List<ProductDetailDto> GetProductDetails();
        Product GetById(int productId);
        IResult Add(Product product);
    }
}