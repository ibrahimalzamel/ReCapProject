using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        CarDetailDto GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null);
        List<CarDetailDto> GetCarsDetailDtos(Expression<Func<CarDetailDto, bool>> filter = null);
        List<CarDetailDto> GetDtoByBrandId(string brandName);
        List<CarDetailDto> GetDtoByColorId(string colorName);
    }
}
