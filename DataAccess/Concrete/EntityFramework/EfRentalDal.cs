using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityrepositoryBase<Rentals, NorthwindContext>, IRentalDal
    {
        public List<CarRentalDetailDto> GetCarRentalDetails(Expression<Func<Rentals, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from rnt in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join cr in context.Cars on rnt.CarId equals cr.CarId
                             join col in context.Colors on cr.ColorId equals col.ColorId
                             join brd in context.Brands on cr.BrandId equals brd.BrandId
                             join cus in context.Customers on rnt.CustomersID equals cus.CustomersID
                             join usr in context.Users on cus.UserID equals usr.UserID
                             select new CarRentalDetailDto
                             {
                                 RentalId = rnt.RentalsID,
                                 CustomerName = usr.FirstName,
                                 CustomerLastName = usr.LastName,
                                 CustomerCompanyName = cus.CompanyName,
                                 CarName = cr.Descriptio,
                                 BrandName = brd.BrandName,
                                 ColorName = col.ColorName,
                                 DailyPrice = cr.DailyPrice,
                                 RentDate = rnt.RentDate,
                                 ReturnDate = rnt.ReturnDate
                             };

                return result.ToList();
            }
        }
    }
}
