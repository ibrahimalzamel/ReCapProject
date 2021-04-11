using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.DataResults;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {

        ICustomerDal _customerDal;
        IUserService _userService;
        public CustomerManager(ICustomerDal customerDal , IUserService userService)
        {
            _customerDal = customerDal;
            _userService = userService;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customers customer)
        {
            if (!CheckIfUserExists(customer.UserID).Success)
            {
                return new ErrorResult(ErrorMessages.CustomerNotAdded);
            }
            _customerDal.Add(customer);
            return new SuccessResult(SuccessMessages.CustomerAdded);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Delete(Customers customer)
        {
            if (!CheckIfCustomerExists(customer.CustomersID).Success)
            {
                return new ErrorResult(ErrorMessages.CustomerNotDeleted);
            }
            _customerDal.Delete(customer);
            return new SuccessResult(SuccessMessages.CustomerDeleted);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IDataResult<List<Customers>> GetAll()
        {
            if (_customerDal.GetAll()==null)
            {
               return  new ErrorDataResult<List<Customers>>(ErrorMessages.CustomerNameAlreadyExistsError);
            }
            return new SuccessDataResult<List<Customers>>(_customerDal.GetAll(), SuccessMessages.CustomersListed);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IDataResult<Customers> GetByID(int id)
        {
            var result = CheckIfCustomerExists(id);
            if (!result.Success)
            {
                return new ErrorDataResult<Customers>(ErrorMessages.CustomerNameAlreadyExistsError);
            }
            return new SuccessDataResult<Customers>(result.Data, SuccessMessages.CustomersListed);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IDataResult<List<Customers>> GetByUserId(int id)
        {
            var result = CheckIfUserInCustomerExists(id);
            if (!result.Success)
            {
                return new ErrorDataResult<List<Customers>>(ErrorMessages.CustomerNameAlreadyExistsError);
            }
            return new SuccessDataResult<List<Customers>>(result.Data, SuccessMessages.CustomersListed);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            if (_customerDal.GetCustomerDetails()==null)
            {
                return new ErrorDataResult<List<CustomerDetailDto>>(ErrorMessages.BrandNameAlreadyExistsError1);
            }
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails(), SuccessMessages.CustomersListed);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customers customer)
        {

            if (!CheckIfUserExists(customer.UserID).Success)
            {
                return new ErrorResult(ErrorMessages.CustomerNotUpdated);
            }
            _customerDal.Update(customer);
            return new SuccessResult(SuccessMessages.CustomerUpdated);
        }

        private IResult CheckIfUserExists(int userId)
        {
            var result = _userService.GetByID(userId);
            if (result.Success == false)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IDataResult <Customers> CheckIfCustomerExists(int id)
        {
            var result = _customerDal.Get(c=>c.CustomersID==id);
            if (result == null)
            {
                return new ErrorDataResult<Customers>();
            }
            return new SuccessDataResult<Customers>(result);
        }
        private IDataResult<List<Customers>> CheckIfUserInCustomerExists(int id)
        {
            var result = _customerDal.GetAll(c=>c.UserID==id);
            if (result == null)
            {
                return new ErrorDataResult<List<Customers>>(result);
            }
            return new SuccessDataResult<List<Customers>>(result);
        }
    }
}
