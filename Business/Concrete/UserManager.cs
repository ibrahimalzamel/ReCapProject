using Business.Abstract;
using Core.Utilities.DataResults;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        public IResult Add(Users user)
        {
            throw new NotImplementedException();
        }

        public IResult Delet(Users user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Users>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Users> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Users user)
        {
            throw new NotImplementedException();
        }
    }
}
