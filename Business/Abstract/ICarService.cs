using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        void  GetAll();
        void Add(Car car);
        void Delete(int carId);
        void Update(Car car);
        List<Car> GetById(int CarId);
    }
}
