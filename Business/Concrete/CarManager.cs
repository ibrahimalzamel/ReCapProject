using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal; 
        }

        public void GetAll()
        {

            foreach (var car in _carDal.GetAll())
            {
                Console.WriteLine("\n***--------- " + car.CarId + " ---------***\n");
                Console.WriteLine("CarId : " + car.CarId);
                Console.WriteLine("BrandId : " + car.BrandId);
                Console.WriteLine("ColorId :" + car.ColorId);
                Console.WriteLine("ModelYear : " + car.ModelYear);
                Console.WriteLine("DailyPrice : " + car.DailyPrice);
                Console.WriteLine("Description : " + car.Description);


            }

        }
        public void Add(Car car)
        {
            _carDal.Add(car);
        }
        public void Delete(int carId)
        {
            _carDal.Delete(carId);
        }
        public void Update(Car car)
        {
            _carDal.Update(car);
        }
        public List<Car> GetById(int CarId)
        {

            return _carDal.GetById(CarId);
        }
    }
}
