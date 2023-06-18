using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICategoryService : IServiceBase<Category>
{
    IDataResult<List<Category>> GetAll();
    IDataResult<Category?> GetById(int categoryId);
}