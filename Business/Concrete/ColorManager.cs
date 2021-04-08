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
                return result;
            }
            _colorDal.Add(color);
            return new SuccessResult(SuccessMessages.ColorAdded);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Delete(Color Color)
        {

            _colorDal.Delete(Color);
            return new SuccessResult(SuccessMessages.ColorDeleted);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),SuccessMessages.ColorListed);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IDataResult<Color> GetByID(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c =>c.ColorId == id),SuccessMessages.ColorListed);
        }


        [ValidationAspect(typeof(ColorValidator))]
        public IDataResult<List<Color>> GetColorName(string colorName)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorName == colorName), SuccessMessages.ColorListed);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color Color)
        {
            var result = CheckIfColorNameExists(Color.ColorName);
            if (result.Success)
            {
                return result;
            }
            _colorDal.Update(Color);
            return new SuccessResult(SuccessMessages.ColorUpdate);
        }

        private IResult CheckIfColorNameExists(string colorName)
        {
            var result = _colorDal.GetAll(c => c.ColorName == colorName).Any();
            if (result)
            {
                return new ErrorResult("ErrorMessages.ColorNameExistsError");
            }

            return new SuccessResult();
        }
    }
}
