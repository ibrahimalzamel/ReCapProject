﻿using Core.DataAccess.EntityFramework;
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
    public class EfCustomerDal : EfEntityrepositoryBase<Customers, NorthwindContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customers, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                /**     var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                             join carI in context.CarImages on c.CarId equals carI.CarId
                             select new CarDetailDto
                             {*/
                var result = from cus in context.Customers 
                             join usr in context.Users on cus.UserID equals usr.Id

                             select new CustomerDetailDto
                             {
                                 CustomerId = cus.CustomersID,
                                 UserId = usr.Id,
                                 UserName = usr.FirstName,
                                 UserLastName = usr.LastName,
                                 CompanyName = cus.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}
