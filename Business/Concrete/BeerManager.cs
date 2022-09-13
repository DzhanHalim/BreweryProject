using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BeerManager : IBeerService
    {
        IBeerDal _beerDal;

        public BeerManager(IBeerDal beerDal)
        {
            _beerDal = beerDal;
        }

        [ValidationAspect(typeof(BeerValidator))]
        public IResult Add(Beer beer)
        {
            _beerDal.Add(beer);
            return new SuccessResult("Success");
        }

        public IResult Delete(Beer beer)
        {
            _beerDal.Delete(beer);
            return new SuccessResult();
        }

        public IDataResult<List<Beer>> GetAll()
        {

            return new SuccessDataResult<List<Beer>>(_beerDal.GetAll(), "");
        }

        public IDataResult<List<Beer>> GetAllByBreweryId(int Id)
        {
            return new SuccessDataResult<List<Beer>>(_beerDal.GetAll(b => b.BreweryId == Id));
        }

        public IDataResult<Beer> GetById(int Id)
        {
            return new SuccessDataResult<Beer>(_beerDal.GetById(b => b.Id == Id), "Success");
        }
    }
}
