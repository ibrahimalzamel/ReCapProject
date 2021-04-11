using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.DataResults;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal ;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }



        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            var result = CheckIfColorNameExists(color.ColorName);
            if (result.Success)
            {
                return new ErrorResult(ErrorMessages.ColorNotAdded);
            }
            _colorDal.Add(color);
            return new SuccessResult(SuccessMessages.ColorAdded);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Delete(Color Color)
        {
            var result = CheckIfColorExists(Color.ColorId);
            if (!result.Success)
            {
                return new  ErrorResult(ErrorMessages.ColorNotDeleted);
            }
            _colorDal.Delete(Color);
            return new SuccessResult(SuccessMessages.ColorDeleted);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IDataResult<List<Color>> GetAll()
        {

            if (_colorDal.GetAll()==null)
            {
                return new ErrorDataResult<List<Color>>(ErrorMessages.ColorNameAlreadyExistsError);
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),SuccessMessages.ColorListed);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IDataResult<Color> GetByID(int id)
        {
            var result = CheckIfColorExists(id);
            if (!result.Success)
            {
                return new ErrorDataResult<Color>(ErrorMessages.ColorNameAlreadyExistsError);
            }
            return new SuccessDataResult<Color>(result.Data,SuccessMessages.ColorListed);
        }


        [ValidationAspect(typeof(ColorValidator))]
        public IDataResult<Color> GetColorName(string colorName)
        {
            var result = CheckIfColorNameExists(colorName);
            if (!result.Success)
            {
                return new ErrorDataResult<Color>(ErrorMessages.ColorNameAlreadyExistsError);
            }
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorName == colorName), SuccessMessages.ColorListed);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color Color)
        {
            var result = CheckIfColorNameExists(Color.ColorName);
            if (result.Success)
            {
                return new ErrorResult(ErrorMessages.ColorNotUpdated);
            }
            _colorDal.Update(Color);
            return new SuccessResult(SuccessMessages.ColorUpdate);
        }


        //*********** Check ***********////

        private IDataResult<Color> CheckIfColorExists(int id)
        {
            var result = _colorDal.Get(c => c.ColorId == id);
            if (result == null)
            {
                return new ErrorDataResult<Color>();
            }
            return new SuccessDataResult<Color>(result);
        }

        private IResult CheckIfColorNameExists(string colorName)
        {
            var result = _colorDal.GetAll(c => c.ColorName == colorName).Any();
            if (!result)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
