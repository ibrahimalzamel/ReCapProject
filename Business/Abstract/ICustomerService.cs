using Core.Utilities.Business;
using Core.Utilities.DataResults;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService : ICrudService<Customers>
    {
       
        IDataResult<List<Customers>> GetByUserId(int id);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();

    }
}
