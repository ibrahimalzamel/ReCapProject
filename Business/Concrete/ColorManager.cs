using Business.Abstract;
using Business.Constants;
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

        public IResult Add(Color Color)
        {
            return new SuccessResult(SuccessMessages.ProductAdded);
        }

        public IResult Delet(Color Color)
        {
            return new SuccessResult(SuccessMessages.ProductAdded);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(SuccessMessages.ProductListed);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c =>c.ColorId == id));
        }

        public IResult Update(Color Color)
        {
            return new SuccessResult(SuccessMessages.ProductAdded);
        }
    }
}
