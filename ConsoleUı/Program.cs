﻿using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Start strat = new Start();

             strat.CarTest();
            //strat.ColorTest();
            //  strat.BrandTest();
        }
    }
}
