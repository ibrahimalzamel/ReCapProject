using Core.Utilities.DataResults;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rentals rental);
        IResult Delet(Rentals rental);
        IResult Update(Rentals rental);
        IDataResult<List<Rentals>> GetAll();
        IDataResult<Rentals> GetById(int id);
    }
}
