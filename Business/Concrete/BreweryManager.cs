using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BreweryManager :IBreweryService
    {
        IBreweryDal _breweryDal;

        public BreweryManager(IBreweryDal breweryDal)
        {
            _breweryDal = breweryDal;
        }

        public IResult Add(Brewery brewery)
        {
            _breweryDal.Add(brewery);
            return new SuccessResult("Success");
        }

        public IResult Delete(Brewery brewery)
        {
            _breweryDal.Delete(brewery);
            return new SuccessResult();
        }

        public IDataResult<List<Brewery>> GetAll()
        {

            return new SuccessDataResult<List<Brewery>>(_breweryDal.GetAll(), "");
        }

        

        public IDataResult<Brewery> GetById(int Id)
        {
            return new SuccessDataResult<Brewery>(_breweryDal.GetById(b => b.Id == Id), "Success");
        }

        public IResult Update(Brewery brewery)
        {
            _breweryDal.Update(brewery);
            return new SuccessResult("");
        }
    }
}
