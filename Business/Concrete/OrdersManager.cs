using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OrdersManager : IOrdersService
    {
        IOrdersDal _ordersDal;

        public OrdersManager(IOrdersDal ordersDal)
        {
            _ordersDal = ordersDal;
        }

        public IResult Add(Orders order)
        {
            _ordersDal.Add(order);
            return new SuccessResult("Success");
        }

        public IResult Delete(Orders order)
        {
            _ordersDal.Delete(order);
            return new SuccessResult();
        }

        public IDataResult<List<Orders>> GetAll()
        {

            return new SuccessDataResult<List<Orders>>(_ordersDal.GetAll(), "");
        }



        public IDataResult<Orders> GetById(int Id)
        {
            return new SuccessDataResult<Orders>(_ordersDal.GetById(b => b.Id == Id), "Success");
        }

        public IResult Update(Orders order)
        {
            _ordersDal.Update(order);
            return new SuccessResult("");
        }
    }
}
