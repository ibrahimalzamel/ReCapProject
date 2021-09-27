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

            CarManager car1 = new CarManager(new EfCarDal());
            var result = car1.GetAll();

            foreach (var car in result.Data)
            {
                Console.WriteLine("Car ID : " + car.CarId);
                Console.WriteLine("BrandId : " + car.BrandId);
                Console.WriteLine("Color ID : " + car.ColorId);
                Console.WriteLine("Daily Price : " + car.DailyPrice);
                Console.WriteLine("Description : " + car.Descriptio);

            }

        }

        public void ColorTest()
        {
            // ***** Color Class manager ******
         //   ColorManager color1 = new ColorManager(new EfColorDal());
            EfColorDal color2 = new EfColorDal();
            var result = color2.Get(c=>c.ColorId==1);
            Console.WriteLine("Color ID : " + result.ColorId);
            Console.WriteLine("Color Name : " + result.ColorName);
            
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
