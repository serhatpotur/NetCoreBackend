using NetCoreBackend.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBackend.Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(int TId);
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(T entity);
    }
}
