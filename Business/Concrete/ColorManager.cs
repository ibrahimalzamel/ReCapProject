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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal ;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color Color)
        {
            _colorDal.Add(Color);
            return new SuccessResult(SuccessMessages.ColorAdded);
        }

        public IResult Delete(Color Color)
        {

            _colorDal.Delete(Color);
            return new SuccessResult(SuccessMessages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),SuccessMessages.ColorListed);
        }

        public IDataResult<Color> GetByID(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c =>c.ColorId == id),SuccessMessages.ColorListed);
        }

        public IDataResult<List<Color>> GetColorName(string colorName)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorName == colorName), SuccessMessages.ColorListed);
        }

        public IResult Update(Color Color)
        {
            _colorDal.Update(Color);
            return new SuccessResult(SuccessMessages.ColorUpdate);
        }
    }
}
