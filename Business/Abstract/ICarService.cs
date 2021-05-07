using Core.Utilities.Business;
using Core.Utilities.DataResults;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService : ICrudService<Car>
    {
      
        IDataResult<List<Car>> GetByBrandId(int id);
        IDataResult<List<Car>> GetByColorId(int id);
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
        IDataResult<List<CarDetailDto>> GetCarsDetailDtos();
        IDataResult<List<CarDetailDto>> GetCarsDetailByColorName(string colorName);
        IDataResult<List<CarDetailDto>> GetCarsDetailByBrandName(string brandName);
        IDataResult<CarDetailDto> GetDtoById(int carId);

        IResult AddTransactionalTest(Car car);
    }
}
