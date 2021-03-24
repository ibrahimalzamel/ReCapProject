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
    public class CustomerManager : ICustomerService
    {

        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal )
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customers customer)
        {
            if (customer.UserID != 0)
            {
                _customerDal.Add(customer);
                return new SuccessResult(SuccessMessages.CustomerAdded);
            }
            else
                return new ErrorResult(ErrorMessages.CustomerNotAdded);
        }

        public IResult Delete(Customers customer)
        {
            if (customer.CustomersID != 0)
            {
                _customerDal.Delete(customer);
                return new SuccessResult(SuccessMessages.CustomerDeleted);
            }
            else
                return new ErrorResult(ErrorMessages.CustomerNotDeleted);
        }

        public IDataResult<List<Customers>> GetAll()
        {
            return new SuccessDataResult<List<Customers>>(_customerDal.GetAll(),SuccessMessages.CustomersListed);
        }

        public IDataResult<Customers> GetById(int id)
        {
            return new SuccessDataResult<Customers>(_customerDal.Get(c => c.CustomersID == id),SuccessMessages.CustomersListed);
        }

        public IResult Update(Customers customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(SuccessMessages.CustomerUpdated);
        }
    }
}
