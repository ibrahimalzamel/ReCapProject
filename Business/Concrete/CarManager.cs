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
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal; 
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {                     
                _carDal.Add(car);
                return new SuccessResult(SuccessMessages.CarAdded);          
        }
      
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(SuccessMessages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
           
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), SuccessMessages.CarsListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.BrandId==id),SuccessMessages.CarsListed);
        }

        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id), SuccessMessages.CarsListed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.DailyPrice>=min && c.DailyPrice<=max),SuccessMessages.CarsListed);
        }

        public IDataResult<Car> GetByID(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id), SuccessMessages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailDtos()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetailDtos(),SuccessMessages.CarsListed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(SuccessMessages.CarUpdated);
        }
    }
}
