using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Business;

public interface IServiceBase<in T>
{
    IResult Add(T entity);
    IResult Update(T entity);
    IResult Delete(T entity);
}