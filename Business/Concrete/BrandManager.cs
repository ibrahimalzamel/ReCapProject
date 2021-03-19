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
            _brandDal.Add(brand);

            return new SuccessResult(SuccessMessages.ProductAdded);
        }

        public IResult Delet(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(SuccessMessages.ProductAdded);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),SuccessMessages.ProductListed);
        }

        public IDataResult<Brand> GetByID(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b=>b.BrandId == id ));

        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);

            return new SuccessResult(SuccessMessages.ProductAdded);
        }

    }
}
