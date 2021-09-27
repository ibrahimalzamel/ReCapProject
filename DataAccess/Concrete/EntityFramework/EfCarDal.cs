using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityrepositoryBase<Car,NorthwindContext>,ICarDal
    {
        public CarDetailDto GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            return GetCarsDetailDtos(filter).FirstOrDefault();
        }

        public List<CarDetailDto> GetCarsDetailDtos(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Descriptio,
                                 ModelYear = c.ModelYear,
                                 CarName = c.CarName,
                                 FuelName = c.FuelName,
                                 ImagePath = c.ImagePath,

                             };
                return filter != null ? result.Where(filter).ToList() : result.ToList();
            }
            
        }

        public List<CarDetailDto> GetDtoByBrandId(string brandName)
        {
            return GetCarsDetailDtos(b => b.BrandName==brandName); 
        }

        public List<CarDetailDto> GetDtoByColorId(string colorName)
        {
            return GetCarsDetailDtos(c =>c.ColorName==colorName);
        }
    }
}
