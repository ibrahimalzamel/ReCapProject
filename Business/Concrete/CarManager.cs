using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
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
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;
        IColorService _colorService;
        public CarManager(ICarDal carDal,IBrandService brandService, IColorService colorService)
        {
            _carDal = carDal;
            _brandService = brandService;
            _colorService = colorService;
        }

        [SecuredOperation("car.add,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            var result = BusinessRules.Run(CheckIfBrandExists(car.BrandId), CheckIfColorExists(car.ColorId));
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
                return new SuccessResult(SuccessMessages.CarAdded);          
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(SuccessMessages.CarDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
           
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), SuccessMessages.CarsListed);
        }


        [CacheAspect]
        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.BrandId==id),SuccessMessages.CarsListed);
        }


        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id), SuccessMessages.CarsListed);
        }


        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.DailyPrice>=min && c.DailyPrice<=max),SuccessMessages.CarsListed);
        }


        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Car> GetByID(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id), SuccessMessages.CarsListed);
        }


        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<List<CarDetailDto>> GetCarsDetailDtos()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetailDtos(),SuccessMessages.CarsListed);
        }


        [SecuredOperation("car.add,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            var result = BusinessRules.Run(CheckIfBrandExists(car.BrandId), CheckIfColorExists(car.ColorId));
            if (result != null)
            {
                return result;
            }
            _carDal.Update(car);
            return new SuccessResult(SuccessMessages.CarUpdated);
        }


        private IResult CheckIfBrandExists(int brandId)
        {
            var result = _brandService.GetByID(brandId);
            if (result == null)
            {
                return new ErrorResult(ErrorMessages.BrandNameAlreadyExistsError1);
            }
            return new SuccessResult();
        }
        private IResult CheckIfColorExists(int colorId)
        {
            var result = _colorService.GetByID(colorId);
            if (result.Data == null)
            {
                return new ErrorResult("ErrorMessages.ColorNotExistsError");
            }
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 5000)
            {
                throw new Exception("");
            }

            Add(car);
            return null;
        }
    }
}
