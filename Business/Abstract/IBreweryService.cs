using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBreweryService
    {
        IDataResult<List<Brewery>> GetAll();
        IDataResult<Brewery> GetById(int Id);

        IResult Add(Brewery brewery);

        IResult Delete(Brewery brewery);
        IResult Update(Brewery brewery);

    }
}
