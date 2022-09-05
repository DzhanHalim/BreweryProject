using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class WholesalerStockManager : IWholesalerStockService
    {
        IWholesalerStockDal _wholesalerStock;

        public WholesalerStockManager(IWholesalerStockDal wholesalerStock)
        {
            _wholesalerStock = wholesalerStock;
        }

        public IResult Add(WholesalerStock stock)
        {
            _wholesalerStock.Add(stock);
            return new SuccessResult("");
        }

        public IDataResult<List<WholesalerStock>> GetAll()
        {
            return new SuccessDataResult<List<WholesalerStock>>(_wholesalerStock.GetAll(), "");

        }

        public IDataResult<List<WholesalerStock>> GetAllByWholesalerId(int Id)
        {
            return new SuccessDataResult<List<WholesalerStock>>(_wholesalerStock.GetAll(s => s.WholesalerId == Id), "");

        }

        public IDataResult<WholesalerStock> GetById(int Id)
        {
            return new SuccessDataResult<WholesalerStock>(_wholesalerStock.GetById(w => w.Id == Id));
        }

        public IResult Update(WholesalerStock stock)
        {
            _wholesalerStock.Update(stock);
            return new SuccessResult("");
        }
    }
}
