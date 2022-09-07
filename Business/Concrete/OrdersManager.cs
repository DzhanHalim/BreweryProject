using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class OrdersManager : IOrdersService
    {
        IOrdersDal _ordersDal;
        IWholesalerStockService _wholesalerStockService;
        IBeerService _beerService;

        public OrdersManager(IOrdersDal ordersDal, IWholesalerStockService wholesalerStockService, IBeerService beerService)
        {
            _ordersDal = ordersDal;
            _wholesalerStockService = wholesalerStockService;
            _beerService = beerService;
        }

        public IResult Add(Orders order)
        {

            IResult result = BusinessRules.Run(CheckIfOrdersGreaterThanStock(order), CheckDuplicateOrder(order),
                CheckIfWholesalerExist(order.WholesalerId), CheckIfOrderEmpty(order));

            if (result != null)
            {
                return result;
            }
            int discount = 0;
            if (order.Quantity > 10)
            {
                discount = 10;
            }
            else if (order.Quantity > 20)
            {
                discount = 20;
            }
            var price = _beerService.GetById(order.BeerId).Data.Price;
            var totalPrice = order.Quantity * price;
            if (discount != 0)
            {
                totalPrice = (totalPrice * discount) / 100;
            }
                        
            order.TotalPrice = totalPrice;
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

        private IResult CheckIfOrderEmpty(Orders order)
        {

            if (order == null)
            {
                return new ErrorResult();

            }
            return new SuccessResult();
        }

        private IResult CheckIfWholesalerExist(int wholesalerId)
        {
            var result = _wholesalerStockService.GetAllByWholesalerId(wholesalerId).Data;
            if (result == null)
            {
                return new ErrorResult();

            }
            return new SuccessResult();
        }

        private IResult CheckDuplicateOrder(Orders order)
        {
            var result = _ordersDal.GetAll(p =>
               p.CustomerId == order.CustomerId
            && p.BeerId == order.BeerId
            && p.Quantity == order.Quantity).Count;
            if (result > 0)
            {
                return new ErrorResult();

            }
            return new SuccessResult();
        }

        private IResult CheckIfOrdersGreaterThanStock(Orders order)
        {
            var result = _wholesalerStockService.GetAll().Data.Where(w => w.WholesalerId == order.WholesalerId &&
             w.BeerId == order.BeerId).ToList();

            int stock = 0;
            foreach (var item in result)
            {
                stock = item.BeersInStock;
            }

            if (stock < order.Quantity)
            {
                return new ErrorResult();

            }
            return new SuccessResult();
        }

    }
}
