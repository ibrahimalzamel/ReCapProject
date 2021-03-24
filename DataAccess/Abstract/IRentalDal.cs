﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rentals>
    {
        List<CarRentalDetailDto> GetCarRentalDetails(Expression<Func<Rentals, bool>> filter = null);
    }
}
