﻿using Core.Utilities.DataResults;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService 
    {
        IResult Add(Customers customer);
        IResult Delet(Customers customer);
        IResult Update(Customers customer);
        IDataResult<List<Customers>> GetAll();
        IDataResult<Customers> GetById(int id);
    }
}
