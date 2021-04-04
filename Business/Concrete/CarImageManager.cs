using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.DataResults;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {

        ICarImageDal _CarImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _CarImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage)
        {
            _CarImageDal.Add(carImage);
            return new SuccessResult(SuccessMessages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _CarImageDal.Delete(carImage);
            return new SuccessResult(SuccessMessages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_CarImageDal.GetAll(),SuccessMessages.CarsImageListed);
        }

        public IDataResult<CarImage> GetByID(int Id)
        {
            return new SuccessDataResult<CarImage>(_CarImageDal.Get(c => c.Id == Id), SuccessMessages.CarsImageListed);
        }

        public IResult Update(CarImage carImage)
        {
            _CarImageDal.Update(carImage);
            return new SuccessResult(SuccessMessages.CarImageUpdated);
        }
        private IResult CheckIfCarImageConuntOfimageCorrect(int imageId)
        {
            var result = _CarImageDal.GetAll(c => c.Id == imageId);
            return new SuccessResult();
        }
    }
}
