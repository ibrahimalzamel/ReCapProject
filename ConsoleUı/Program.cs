using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager1 = new CarManager(new InMemoryCar());

            Console.WriteLine("================== LİST ==================");
            carManager1.GetAll();

            carManager1.Add(new Car { CarId = 6, BrandId = 1, ColorId = 1, ModelYear = new DateTime(1995,1,1), DailyPrice = 85000, Description = "Eski Araba" });
            Console.WriteLine("\n================== Add ==================\n");
            carManager1.GetAll();

            carManager1.Delete(1);
            Console.WriteLine("\n================== Delete ==================\n");
            carManager1.GetAll();

            carManager1.Update(new Car { CarId = 4, BrandId = 2, ColorId = 3, ModelYear = new DateTime(2005,1,1), DailyPrice = 185000, Description = "Yeni Araba" });
            Console.WriteLine("\n================== Update ==================\n");
            carManager1.GetAll();
            //carManager1.GetById(2);

            Console.WriteLine("\n================== Brand ==================\n");

            //     BrandManager brandManager1 = new BrandManager(IMemoryBrand())

            BrandManager brandManager1 = new BrandManager(new IMemoryBrand());
            Console.WriteLine("================== LİST ==================");
            brandManager1.GetAll();
            brandManager1.Add(new Brand {BrandId =5, BrandName="Oodi" });
            Console.WriteLine("\n================== Add ==================\n");
            brandManager1.GetAll();
            brandManager1.Delete(1);
            Console.WriteLine("\n================== Delete ==================\n");
            brandManager1.GetAll();
            brandManager1.Update(new Brand { BrandId = 2, BrandName = "Volvo" });
            Console.WriteLine("\n================== Update ==================\n");
            brandManager1.GetAll();
           // brandManager1.GetById(2);

        }
    }
}
