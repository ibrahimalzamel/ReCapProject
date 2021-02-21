﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IBrandDal 
    {
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(int brandId);
        List<Brand> GetAll();
        List<Brand> GetById(int BrandId);
    }
}
