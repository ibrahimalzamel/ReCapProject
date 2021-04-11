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
            if (CheckIfBrandNameExists(brand.BrandName).Success)
            {
                return new ErrorResult(ErrorMessages.BrandNotAdded);
            }
            _brandDal.Add(brand);
            return new SuccessResult(SuccessMessages.BrandAdded);
           
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Delete(Brand brand)
        {
            if (!CheckIfBrandExists(brand.BrandId).Success)
            {
                return new ErrorResult(ErrorMessages.BrandNotDeleted);
            }
            _brandDal.Delete(brand);
            return new SuccessResult(SuccessMessages.BrandDeleted);
        }

        
        [ValidationAspect(typeof(BrandValidator))]
        public IDataResult<List<Brand>> GetAll()
        {
            return _brandDal.GetAll()==null
                ? new ErrorDataResult<List<Brand>>(ErrorMessages.BrandNameAlreadyExistsError1)
                : (IDataResult<List<Brand>>)new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),SuccessMessages.BrandsListed);
        }


        [ValidationAspect(typeof(BrandValidator))]
        public IDataResult<Brand> GetBrandName(string brandName)
        {
            var result = CheckIfBrandNameExists(brandName);
            if (!result.Success)
            {
                return new ErrorDataResult<Brand>(ErrorMessages.BrandNameAlreadyExistsError1);
            }

            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandName == brandName), SuccessMessages.BrandsListed);
        }


        [ValidationAspect(typeof(BrandValidator))]
        public IDataResult<Brand> GetByID(int id)
        {
            var result = CheckIfBrandExists(id);
            if (!result.Success)
            {
                return new ErrorDataResult<Brand>(ErrorMessages.BrandNameAlreadyExistsError1);
            }
            return new SuccessDataResult<Brand>(result.Data,SuccessMessages.BrandsListed);

        }
     

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            if (CheckIfBrandNameExists(brand.BrandName).Success)
            {
                return new ErrorResult(ErrorMessages.BrandNotUpdated);
            }
            _brandDal.Update(brand);
            return new SuccessResult(SuccessMessages.BrandUpdate);
        }

        private IDataResult<Brand> CheckIfBrandExists(int id)
        {
            var result = _brandDal.Get(b => b.BrandId == id);
            if (result == null)
            {
                return new ErrorDataResult<Brand>();
            }
            return new SuccessDataResult<Brand>(result);
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
