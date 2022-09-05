using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IWholesalerStockService
    {
        IDataResult<List<WholesalerStock>> GetAll();
        IDataResult<List<WholesalerStock>> GetAllByWholesalerId(int Id);
        IDataResult<WholesalerStock> GetById(int Id);
        IResult Add(WholesalerStock stock);
        IResult Update(WholesalerStock stock);


    }
}
