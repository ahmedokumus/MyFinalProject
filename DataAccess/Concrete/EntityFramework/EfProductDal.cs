﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
{
    public List<ProductDetailDto> GetProductDetails()
    {
        using var context = new NorthwindContext();
        var result =
            from product in context.Products
            join category in context.Categories
                on product.CategoryId equals category.CategoryId
            select new ProductDetailDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                CategoryName = category.CategoryName,
                UnitsInStock = product.UnitsInStock,
                UnitPrice = product.UnitPrice
            };

        return result.ToList();
    }
}