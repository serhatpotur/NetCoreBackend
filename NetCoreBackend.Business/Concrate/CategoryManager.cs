using NetCoreBackend.Business.Abstract;
using NetCoreBackend.Core.Utilities.Results.Abstract;
using NetCoreBackend.Core.Utilities.Results.Concrate;
using NetCoreBackend.DataAccess.Abstract;
using NetCoreBackend.Entities.Concrate;

namespace NetCoreBackend.Business.Concrate;

public class CategoryManager : ICategoryService
{
    ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public IResult Add(Category entity)
    {
        throw new NotImplementedException();
    }

    public IResult Delete(Category entity)
    {
        throw new NotImplementedException();
    }

    public IDataResult<List<Category>> GetAll()
    {
        return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
    }

    public IDataResult<Category> GetById(int TId)
    {
        throw new NotImplementedException();
    }

    public IResult Update(Category entity)
    {
        throw new NotImplementedException();
    }
}
