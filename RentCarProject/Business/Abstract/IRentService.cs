using Core.Utility.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentService
    {
        IDataResult<List<Rent>> GetAll();

        IResult Add(Rent rent);
        IResult Delete(Rent rent);
        IResult Update(Rent rent);
    }
}
