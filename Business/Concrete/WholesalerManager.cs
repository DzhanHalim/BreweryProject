using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class WholesalerManager : IWholesalerService
    {
        IWholesalerDal _wholesalerDal;

        public WholesalerManager(IWholesalerDal wholesalerDal)
        {
            _wholesalerDal = wholesalerDal;
        }

        public IResult Add(Wholesaler wholesaler)
        {
            _wholesalerDal.Add(wholesaler);
            return new SuccessResult("Success");
        }

        public IResult Delete(Wholesaler wholesaler)
        {
            _wholesalerDal.Delete(wholesaler);
            return new SuccessResult();
        }

        public IDataResult<List<Wholesaler>> GetAll()
        {

            return new SuccessDataResult<List<Wholesaler>>(_wholesalerDal.GetAll(), "");
        }



        public IDataResult<Wholesaler> GetById(int Id)
        {
            return new SuccessDataResult<Wholesaler>(_wholesalerDal.GetById(b => b.Id == Id), "Success");
        }

        public IResult Update(Wholesaler wholesaler)
        {
            _wholesalerDal.Update(wholesaler);
            return new SuccessResult("");
        }

    }
}
