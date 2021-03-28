using Core.Entities;
using Core.Utilities.DataResults;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public interface ICrudService<T> 
         where T : class , IEntity ,new()
    {
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(T entity);
        IDataResult<T> GetByID(int Id);
        IDataResult<List<T>> GetAll();
    }
}
