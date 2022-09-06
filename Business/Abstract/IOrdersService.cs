using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IOrdersService 
    {
        IDataResult<List<Orders>> GetAll();
        IDataResult<Orders> GetById(int Id);

        IResult Add(Orders order);

        IResult Delete(Orders order);
        IResult Update(Orders order);
    }
}
