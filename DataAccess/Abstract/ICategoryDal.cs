using Entities.Concrete;

namespace DataAccess.Abstract;

public interface ICategoryDal
{
    void Add(Category category);
}