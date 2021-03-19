using Core.Utilities.DataResults;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(Users user);
        IResult Delet(Users user);
        IResult Update(Users user);
        IDataResult<List<Users>> GetAll();
        IDataResult<Users> GetById(int id);
    }
}
