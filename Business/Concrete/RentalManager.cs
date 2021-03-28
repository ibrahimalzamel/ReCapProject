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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rentals rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(SuccessMessages.RentalAdded);
        }

        public IResult Delete(Rentals rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(SuccessMessages.RentalDeleted);
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccessDataResult<List<Rentals>>(_rentalDal.GetAll(), SuccessMessages.RentalListed);
        }

        public IDataResult <List<Rentals>> GetByCarId(int id)
        {
            return new SuccessDataResult<List<Rentals>>(_rentalDal.GetAll(r => r.CarId == id), SuccessMessages.RentalListed);
        }

        public IDataResult <List<Rentals>> GetByCustomerId(int id)
        {
            return new SuccessDataResult<List<Rentals>>(_rentalDal.GetAll(r => r.CustomersID == id), SuccessMessages.RentalListed);
        }

        public IDataResult<Rentals> GetByID(int id)
        {
            return new SuccessDataResult<Rentals>(_rentalDal.Get(r => r.RentalsID == id), SuccessMessages.RentalListed);
        }

        public IDataResult<List<CarRentalDetailDto>> GetCarRentalDetails()
        {
            return new SuccessDataResult<List<CarRentalDetailDto>>(_rentalDal.GetCarRentalDetails(), SuccessMessages.RentalListed);
        }

        public IResult Update(Rentals rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(SuccessMessages.RentalUpdated);
        }

      
    }
}
