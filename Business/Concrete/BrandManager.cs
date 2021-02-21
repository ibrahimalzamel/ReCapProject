using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {

        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void Add(Brand brand)
        {
            _brandDal.Add(brand);

        }
        public void Delete(int brandId)
        {
            _brandDal.Delete(brandId);
        }
        public void GetAll()
        {
            foreach (var brand in _brandDal.GetAll())
            {
                Console.WriteLine("\n------------" + brand.BrandId + "----------\n");
                Console.WriteLine("BrandId : " + brand.BrandId);
                Console.WriteLine("BrandName : " + brand.BrandName);

            }
        }
        public List<Brand> GetById(int BrandId)
        {
            return _brandDal.GetById(BrandId);
        }
        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
