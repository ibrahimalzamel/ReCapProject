using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class Start
    {

        public void CarTest()
        {

            // ***** Car Class manager ******
            CarManager car1 = new CarManager(new EfCarDal());
            //car1.Add(new Car
            //{
            //    CarId = 30,
            //    BrandId = 20,
            //    ColorId = 10,
            //    ModelYear = new DateTime(2010, 2, 2),
            //    DailyPrice = 20000,
            //    Description = "test"
            //});            
            var result = car1.GetAll();

            foreach (var car in result.Data)
            {
                Console.WriteLine("Car ID : " + car.CarId);
                Console.WriteLine("BrandId : " + car.BrandId);
                Console.WriteLine("Color ID : " + car.ColorId);
                Console.WriteLine("Daily Price : " + car.DailyPrice);
                Console.WriteLine("Description : " + car.Descriptio);

            }

            //foreach (var car in car1.GetAllByBrandId(5).Data)
            //{
            //    Console.WriteLine("BrandId : " + car.BrandId);
            //}

            //foreach (var car in car1.GetByDailyPrice(20, 50).Data)
            //{
            //    Console.WriteLine("Daily Price : " + car.DailyPrice);
            //}
        }

        public void ColorTest()
        {
            // ***** Color Class manager ******
            ColorManager color1 = new ColorManager(new EfColorDal());
            //  color1.Add(new Color { ColorId = 88, ColorName = "Mavi" });
            var result = color1.GetAll();
            foreach (var color in result.Data)
            {
                Console.WriteLine("Color ID : " + color.ColorId);
                Console.WriteLine("Color Name : " + color.ColorName);
            }
        }

        public void BrandTest()
        {
            // ***** Brand Class manager ******
            BrandManager brand1 = new BrandManager(new EfBrandDal());
           // brand1.Add(new Brand { BrandId = 50, BrandName = "Toyota" });
            foreach (var brand in brand1.GetAll().Data)
            {
                Console.WriteLine("Brand ID : " + brand.BrandId);
                Console.WriteLine("Brand Name : " + brand.BrandName);
            }
        }
    }
}
