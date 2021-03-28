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
    public interface IRentalService : ICrudService<Rentals>
    {
       
        IDataResult<List<Rentals>> GetByCarId(int id);
        IDataResult<List<Rentals>> GetByCustomerId(int id);
        IDataResult<List<CarRentalDetailDto>> GetCarRentalDetails();

    }
}
