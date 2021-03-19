using Core.Utilities.DataResults;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color Color);
        IResult Delet(Color Color);
        IResult Update(Color Color);
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int id);

    }
}
