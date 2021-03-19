using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Utilities.Results;
using Core.Utilities.DataResults;
using Business.Constants;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {

        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            return new SuccessResult(SuccessMessages.ProductAdded);
        }

        public IResult Delet(Brand brand)
        {
            return new SuccessResult(SuccessMessages.ProductAdded);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(SuccessMessages.ProductListed);
        }

        public IDataResult<Brand> GetByID(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b=>b.BrandId == id ));

        }

        public IResult Update(Brand brand)
        {
            return new SuccessResult(SuccessMessages.ProductAdded);
        }

    }
}
