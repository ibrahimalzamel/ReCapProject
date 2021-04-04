using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.DataResults;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService : ICrudService<User>
    {
      
        IDataResult<List<User>> GetAllByUserName(string name);
        IDataResult<User> GetByUserName(string name);
        IDataResult<List<User>> GetAllByUserLastName(string lastName);
        User GetByMail(string email);
        List<OperationClaim> GetClaims(User user);
    }
}
