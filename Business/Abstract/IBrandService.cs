using Core.Utilities.Business;
using Core.Utilities.DataResults;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public  interface IBrandService : ICrudService<Brand>
    {
        IDataResult <Brand> GetBrandName(string brandName);
    }
}
