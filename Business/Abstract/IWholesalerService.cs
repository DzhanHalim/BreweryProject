using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IWholesalerService
    {
        IDataResult<List<Wholesaler>> GetAll();
        IDataResult<Wholesaler> GetById(int Id);

        IResult Add(Wholesaler wholesaler);

        IResult Delete(Wholesaler wholesaler);
        IResult Update(Wholesaler wholesaler);
    }
}
