using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class IMemoryBrand : IBrandDal
    {

        List<Brand> _brands;

        public IMemoryBrand()
        {
            _brands = new List<Brand>
            {
                new Brand { BrandId = 1 , BrandName= "BMV" },
                new Brand { BrandId = 2 , BrandName= "Fiat" },
                new Brand { BrandId = 3 , BrandName= "Opel" },
                new Brand { BrandId = 4 , BrandName= "Renault" }
            };
        }
      
        public void Add(Brand brand)
        {
            _brands.Add(brand);
        }

        public void Delete(int brandId)
        {
            Brand brandToDelete = _brands.SingleOrDefault(b => b.BrandId == brandId);
            _brands.Remove(brandToDelete);
        }

        public List<Brand> GetAll()
        {
            return _brands;
        }

        public List<Brand> GetById(int BrandId)
        {
            return _brands.Where(b => b.BrandId == BrandId).ToList();
        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
            brandToUpdate.BrandName = brand.BrandName; 
        }
    }
}
