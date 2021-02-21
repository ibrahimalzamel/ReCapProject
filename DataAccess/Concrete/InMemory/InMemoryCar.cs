using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq; 
namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCar : ICarDal
    {
        List<Car> _cars;

        public InMemoryCar()
        {
            _cars = new List<Car> 
            {
              new Car {CarId=1,BrandId=2,ColorId=3,ModelYear=new DateTime(2010,1,1),DailyPrice=125200,Description="Clasic Araba"},
              new Car {CarId=2,BrandId=1,ColorId=1,ModelYear=new DateTime(2012,1,1),DailyPrice=165000,Description="Spor Araba"},
              new Car {CarId=3,BrandId=2,ColorId=3,ModelYear=new DateTime(2019,1,1),DailyPrice=131000,Description="ikili kapı Araba"},
              new Car {CarId=4,BrandId=1,ColorId=2,ModelYear=new DateTime(2015,1,1),DailyPrice=152000,Description="Uçak Gibi Araba"},
              new Car {CarId=5,BrandId=3,ColorId=1,ModelYear=new DateTime(2005,1,1),DailyPrice=100000,Description="İş Araba"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(int carId)
        {
            Car carToDelet = _cars.SingleOrDefault(c => c.CarId == carId);
            _cars.Remove(carToDelet);
        }

        public List<Car> GetById(int CarId)
        {

            return _cars.Where(c => c.CarId == CarId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public  List<Car> GetAll()
        {
            return _cars; 
        }

        
    }
}
