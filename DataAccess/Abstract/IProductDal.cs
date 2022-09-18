using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    /*
    I -> Interface olduğunu anlatır.
    Product -> Hangi tabloya karşılık geldiğini, yani hangi Entity olduğunu anlatır.
    Dal -> Data Access Layer -> Hangi katmana karşılık geldiğini anlatır.
    IProductDal -> product entity(tablo)'sinin DAL(Data Access Layer)'ını yazıyorum demek.
    */
    public interface IProductDal : IEntityRepository<Product>
    {

    }
}