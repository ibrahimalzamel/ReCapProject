using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
        ICarService _carService;
        ICustomerService _customerService;
        public RentalManager(IRentalDal rentalDal , ICarService carService, ICustomerService customerService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _customerService = customerService;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rentals rental)
        {
            var result = BusinessRules.Run(CheckIfCarExists(rental.CarId), CheckIfCustomerExists(rental.CustomersID));
            if (result != null)
            {
                return new ErrorResult(ErrorMessages.RentalNotAdded);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(SuccessMessages.RentalAdded);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Delete(Rentals rental)
        {
            if (!CheckIfRentalExists(rental.RentalsID).Success)
            {
                return new ErrorResult(ErrorMessages.RentalNotDeleted);
            }  
            _rentalDal.Delete(rental);
            return new SuccessResult(SuccessMessages.RentalDeleted);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IDataResult<List<Rentals>> GetAll()
        {
            if (_rentalDal.GetAll()==null)
            {
                return new ErrorDataResult<List<Rentals>>(ErrorMessages.RentalNameAlreadyExistsError);
            }
            return new SuccessDataResult<List<Rentals>>(_rentalDal.GetAll(), SuccessMessages.RentalListed);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IDataResult <List<Rentals>> GetByCarId(int id)
        {
            var result = CheckIfCarInRentalExists(id);
            if (!result.Success)
            {
                return new ErrorDataResult<List<Rentals>>(ErrorMessages.RentalNameAlreadyExistsError);
            }
            return new SuccessDataResult<List<Rentals>>(result.Data, SuccessMessages.RentalListed);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IDataResult <List<Rentals>> GetByCustomerId(int id)
        {
            var result = CheckIfCustomerInRentalExists(id);
            if (!result.Success)
            {
                return new ErrorDataResult<List<Rentals>>(ErrorMessages.RentalNameAlreadyExistsError);
            }
            return new SuccessDataResult<List<Rentals>>(result.Data, SuccessMessages.RentalListed);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IDataResult<Rentals> GetByID(int id)
        {
           var result = CheckIfRentalExists(id);
            if (!result.Success)
            {
                return new ErrorDataResult<Rentals>(ErrorMessages.RentalNameAlreadyExistsError);
            }
            return new SuccessDataResult<Rentals>(_rentalDal.Get(r => r.RentalsID == id), SuccessMessages.RentalListed);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IDataResult<List<CarRentalDetailDto>> GetCarRentalDetails()
        {
            if (_rentalDal.GetCarRentalDetails()==null)
            {
                return new ErrorDataResult<List<CarRentalDetailDto>>(ErrorMessages.RentalNameAlreadyExistsError);
            }
            return new SuccessDataResult<List<CarRentalDetailDto>>(_rentalDal.GetCarRentalDetails(), SuccessMessages.RentalListed);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rentals rental)
        {
            var result = BusinessRules.Run(CheckIfCarExists(rental.CarId), CheckIfCustomerExists(rental.CustomersID));
            if (result != null)
            {
                return new ErrorResult(ErrorMessages.RentalNotAdded);
            }
            _rentalDal.Update(rental);
            return new SuccessResult(SuccessMessages.RentalUpdated);
        }

        //*********** Check ***********////
        private IDataResult<Rentals> CheckIfRentalExists(int id)
        {
            var result = _rentalDal.Get(r => r.RentalsID == id);
            if (result == null)
            {
                return new ErrorDataResult<Rentals>();
            }
            return new SuccessDataResult<Rentals>(result);
        }
        private IResult CheckIfCarExists(int CarId)
        {
            var result = _carService.GetByID(CarId);
            if (result.Data == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IResult CheckIfCustomerExists(int customerId)
        {
            var result = _customerService.GetByID(customerId);
            if (result.Data == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IDataResult<List<Rentals>> CheckIfCarInRentalExists(int id)
        {
            var result = _rentalDal.GetAll(r => r.CarId == id);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Rentals>>();
            }
            return new SuccessDataResult<List<Rentals>>(result);
        }
        private IDataResult<List<Rentals>> CheckIfCustomerInRentalExists(int id)

        {
            var result = _rentalDal.GetAll(r=>r.CustomersID==id);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Rentals>>();
            }
            return new SuccessDataResult<List<Rentals>>(result);
        }

    }
}
