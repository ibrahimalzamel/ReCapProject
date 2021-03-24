using Business.Abstract;
using Business.Constants;
using Core.Utilities.DataResults;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            if (user.FirstName == "" || user.LastName == "")
            {
                return new ErrorResult(ErrorMessages.FirstNameLastNameInvalid);
            }

            _userDal.Add(user);
            return new SuccessResult(SuccessMessages.UserAdded);
        }

        public IResult Delete(User user)
        {
            if (user.UserID != 0)
            {
                _userDal.Delete(user);
                return new SuccessResult(SuccessMessages.UserDeleted);
            }
            else
            {
                return new ErrorResult(ErrorMessages.UserNotDeleted);
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), SuccessMessages.UsersListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.UserID==id),SuccessMessages.UsersListed);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(SuccessMessages.UserUpdated);
        }
    }
}
