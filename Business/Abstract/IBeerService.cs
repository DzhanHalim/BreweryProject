using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBeerService
    {
        IDataResult<List<Beer>> GetAll();
        IDataResult<Beer> GetById(int Id);
        // FR1
        IDataResult<List<Beer>> GetAllByBreweryId(int Id);
        
        // FR2
        IResult Add(Beer product);
        // FR3
        IResult Delete(Beer product);


    }
}
