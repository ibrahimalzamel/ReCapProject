﻿using Core.Utilities.Business;
using Core.Utilities.DataResults;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService : ICrudService<Color>
    {
        IDataResult<Color> GetColorName(string colorName);
    }
}
