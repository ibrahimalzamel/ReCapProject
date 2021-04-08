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
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {

        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
      
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            var result = CheckIfBrandNameExists(brand.BrandName);
            if (result.Success)
            {
                return result;
            }
            _brandDal.Add(brand);
            return new SuccessResult(SuccessMessages.BrandAdded);
           
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(SuccessMessages.BrandDeleted);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),SuccessMessages.BrandsListed);
        }


        [ValidationAspect(typeof(BrandValidator))]
        public IDataResult<List<Brand>> GetBrandName(string brandName)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => b.BrandName == brandName), SuccessMessages.BrandsListed);
        }


        [ValidationAspect(typeof(BrandValidator))]
        public IDataResult<Brand> GetByID(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b=>b.BrandId == id ),SuccessMessages.BrandsListed);

        }
     
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            var result = CheckIfBrandNameExists(brand.BrandName);
            if (result != null)
            {
                return result;
            }
            _brandDal.Update(brand);
            return new SuccessResult(SuccessMessages.BrandUpdate);
        }


        private IResult CheckIfBrandNameExists(string brandName)
        {
            var result = _brandDal.GetAll(b => b.BrandName == brandName).Any();
            if (!result)
            {
                return new ErrorResult(ErrorMessages.BrandNameAlreadyExistsError1);
            }
            return new SuccessResult();
        }
    }
}
