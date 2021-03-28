﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
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

        public IDataResult<User> GetByID(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.UserID==id),SuccessMessages.UsersListed);
        }

        public IDataResult<List<User>> GetAllByUserLastName(string lastName)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u=>u.LastName==lastName), SuccessMessages.UsersListed);
        }

        public IDataResult<List<User>> GetAllByUserName(string name)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.FirstName == name), SuccessMessages.UsersListed);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(SuccessMessages.UserUpdated);
        }

        public IDataResult<User> GetByUserName(string name)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.FirstName == name), SuccessMessages.UsersListed);
        }
    }
}
