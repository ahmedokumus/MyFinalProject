using Entities.Concrete;
using System.Collections.Generic;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllCategoryId(int id);
        List<Product> GetByUnitePrice(decimal min, decimal max);
        List<ProductDetailDto> GetProductDetails();
    }
}