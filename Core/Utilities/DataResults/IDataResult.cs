﻿using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.DataResults
{
    public interface IDataResult<T> : IResult
    {
        T Data { get ;  }
    }
}
