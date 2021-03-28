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
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {

        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal )
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customers customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(SuccessMessages.CustomerAdded);
        }
        public IResult Delete(Customers customer)
        {
                _customerDal.Delete(customer);
                return new SuccessResult(SuccessMessages.CustomerDeleted);
        }

        public IDataResult<List<Customers>> GetAll()
        {
            return new SuccessDataResult<List<Customers>>(_customerDal.GetAll(),SuccessMessages.CustomersListed);
        }

        public IDataResult<Customers> GetByID(int id)
        {
            return new SuccessDataResult<Customers>(_customerDal.Get(c => c.CustomersID == id),SuccessMessages.CustomersListed);
        }

        public IDataResult<List<Customers>> GetByUserId(int id)
        {
            return new SuccessDataResult<List<Customers>>(_customerDal.GetAll(c=>c.UserID ==id), SuccessMessages.CustomersListed);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails(), SuccessMessages.CustomersListed);
        }

        public IResult Update(Customers customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(SuccessMessages.CustomerUpdated);
        }
    }
}
