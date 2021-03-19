using Business.Abstract;
using Business.Constants;
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

        public IResult Add(Car car)
        {
            if (car.CarId<2)
            {
                //magic strings
                return new SuccessResult(SuccessMessages.ProductAdded);
            }
            _carDal.Add(car);

            return new ErrorResult(ErrorMessages.MaintenanceTime);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(SuccessMessages.ProductAdded);
        }

        public IDataResult<List<Car>> GetAll()
        {
           
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), SuccessMessages.ProductAdded);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.BrandId==id),SuccessMessages.ProductAdded);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.DailyPrice>=min && c.DailyPrice<=max),SuccessMessages.ProductAdded);
        }

        public IDataResult<Car> GetByID(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id), SuccessMessages.ProductAdded);
        }

        public IDataResult<List<CarDetailDto>> GetOrdersDetailDtos()
        {
            return new ErrorDataResult<List<CarDetailDto>>(_carDal.GetOrdersDetailDtos(),ErrorMessages.MaintenanceTime);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(SuccessMessages.ProductAdded);
        }
    }
}
