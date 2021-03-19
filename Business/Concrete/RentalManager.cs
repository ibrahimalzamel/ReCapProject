using Business.Abstract;
using Core.Utilities.DataResults;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    class RentalManager : IRentalService
    {
        public IResult Add(Rentals rental)
        {
            throw new NotImplementedException();
        }

        public IResult Delet(Rentals rental)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Rentals> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rentals rental)
        {
            throw new NotImplementedException();
        }
    }
}
