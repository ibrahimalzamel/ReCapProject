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
            if (CheckIfUserExists(customer.UserID)==null)
            {
                return new ErrorResult(ErrorMessages.CustomerNotAdded);
            }
            _customerDal.Add(customer);
            return new SuccessResult(SuccessMessages.CustomerAdded);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Delete(Customers customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(SuccessMessages.CustomerDeleted);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IDataResult<List<Customers>> GetAll()
        {
            return new SuccessDataResult<List<Customers>>(_customerDal.GetAll(), SuccessMessages.CustomersListed);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IDataResult<Customers> GetByID(int id)
        {
            return new SuccessDataResult<Customers>(_customerDal.Get(c => c.CustomersID == id), SuccessMessages.CustomersListed);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IDataResult<List<Customers>> GetByUserId(int id)
        {
            return new SuccessDataResult<List<Customers>>(_customerDal.GetAll(c => c.UserID == id), SuccessMessages.CustomersListed);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails(), SuccessMessages.CustomersListed);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customers customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(SuccessMessages.CustomerUpdated);
        }

        private IResult CheckIfUserExists(int userId)
        {
            var result = _userService.GetByID(userId);
            if (result.Data == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        //private IResult CheckIfCustomerNameExists(string brandName)
        //{
        //    var result = _customerDal.GetAll(c =>c.CompanyName == brandName).Any();
        //    if (!result)
        //    {
        //        return new ErrorResult(ErrorMessages.BrandNameAlreadyExistsError1);
        //    }
        //    return new SuccessResult();
        //}
    }
}
