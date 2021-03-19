using Business.Abstract;
using Core.Utilities.DataResults;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        public IResult Add(Customers customer)
        {
            throw new NotImplementedException();
        }

        public IResult Delet(Customers customer)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Customers>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Customers> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Customers customer)
        {
            throw new NotImplementedException();
        }
    }
}
