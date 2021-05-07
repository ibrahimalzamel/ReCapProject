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
using System.Linq;
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

       // [SecuredOperation("car.add,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            var result = BusinessRules.Run(CheckIfBrandExists(car.BrandId), CheckIfColorExists(car.ColorId));
            if (result!=null)
            {
                return new ErrorResult(ErrorMessages.CarNotAdded);
            }
            _carDal.Add(car);
            return new SuccessResult(SuccessMessages.CarAdded);          
        }

      //  [SecuredOperation("car.add,admin")]
       //[ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
            if (!CheckIfCarExists(car.CarId).Success)
            {
                return new ErrorResult(ErrorMessages.CarNotDeleted);
            }
            _carDal.Delete(car);
            return new SuccessResult(SuccessMessages.CarDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (_carDal.GetAll()==null)
            {
                return new ErrorDataResult<List<Car>>(ErrorMessages.CarNameAlreadyExistsError);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), SuccessMessages.CarsListed);
        }


        [CacheAspect]
        public IDataResult<List<Car>> GetByBrandId(int id)
        {
            var result = CheckIfBrandInCarExists(id);

            if (!result.Success)
            {
                return new ErrorDataResult<List<Car>>(ErrorMessages.CarNameAlreadyExistsError);
            }
            return new SuccessDataResult<List<Car>>(result.Data,SuccessMessages.CarsListed);
        }


        //[ValidationAspect(typeof(CarValidator))]
        [CacheAspect]
        public IDataResult<List<Car>> GetByColorId(int id)
        {
            var result = CheckIfColorInCarExists(id);
            if (!result.Success)
            {
                return new ErrorDataResult<List<Car>>(ErrorMessages.CarNameAlreadyExistsError);
            }
            return new SuccessDataResult<List<Car>>(result.Data, SuccessMessages.CarsListed);
        }


        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            if (_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max)==null)
            {
                return new ErrorDataResult<List<Car>>(ErrorMessages.CarNameAlreadyExistsError);

            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.DailyPrice>=min && c.DailyPrice<=max),SuccessMessages.CarsListed);
        }


        [CacheAspect]
       // [PerformanceAspect(5)]
        public IDataResult<Car> GetByID(int id)
        {
            var result = CheckIfCarExists(id);
            if (!result.Success)
            {
                return new ErrorDataResult<Car>(ErrorMessages.CarNameAlreadyExistsError);
            }
            return new SuccessDataResult<Car>(result.Data, SuccessMessages.CarsListed);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<List<CarDetailDto>> GetCarsDetailDtos()
        {
            if (_carDal.GetCarsDetailDtos()==null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(ErrorMessages.CarNameAlreadyExistsError);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetailDtos(), SuccessMessages.CarsListed);

        }


      //   [SecuredOperation("car.add,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            var result = BusinessRules.Run(CheckIfBrandExists(car.BrandId), CheckIfColorExists(car.ColorId));
            if (result!=null)
            {
                return new ErrorResult(ErrorMessages.CarNotUpdated);
            }
            _carDal.Update(car);
            return new SuccessResult(SuccessMessages.CarUpdated);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailByColorName(string colorName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetDtoByColorId(colorName));
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailByBrandName(string brandName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetDtoByBrandId(brandName));
        }

        public IDataResult<CarDetailDto> GetDtoById(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetails(c => c.CarId == carId));
        }

        //*********** Check ***********////

        private IResult CheckIfBrandExists(int brandId)
        {
            var result = _brandService.GetByID(brandId);
            if (result.Data == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IResult CheckIfColorExists(int colorId)
        {
            var result = _colorService.GetByID(colorId);
            if (result.Data == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IDataResult<List<Car>> CheckIfBrandInCarExists(int id)
        {
            var result = _carDal.GetAll(c => c.BrandId == id);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Car>>();
            }
            return new SuccessDataResult<List<Car>>(result);
        }
        private IDataResult<List<Car>> CheckIfColorInCarExists(int id)

        {
            var result = _carDal.GetAll(c => c.ColorId == id);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Car>>();
            }
            return new SuccessDataResult<List<Car>>(result);
        }
        private IDataResult<Car> CheckIfCarExists(int id)
        {
            var result = _carDal.Get(c => c.CarId == id);
            if (result == null)
            {
                return new ErrorDataResult<Car>();
            }
            return new SuccessDataResult<Car>(result);
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
