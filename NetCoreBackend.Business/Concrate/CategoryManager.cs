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
        _categoryDal.Add(entity);
        return new SuccessResult();
    }

    public IResult Delete(Category entity)
    {
        _categoryDal.Delete(entity);
        return new SuccessResult();
    }

    public IDataResult<List<Category>> GetAll()
    {
        return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
    }

    public IDataResult<Category> GetById(int TId)
    {
        return new SuccessDataResult<Category>(_categoryDal.Get(x => x.CategoryId == TId));
    }

    public IResult Update(Category entity)
    {
        _categoryDal.Update(entity);
        return new SuccessResult();
    }
}
