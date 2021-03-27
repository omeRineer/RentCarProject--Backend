using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utility.BusinessRules;
using Core.Utility.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentManager : IRentService
    {
        IRentDal _rentDal;

        public RentManager(IRentDal rentDal)
        {
            _rentDal = rentDal;
        }

        [ValidationAspect(typeof(RentValidator))]
        public IResult Add(Rent rent)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            _rentDal.Add(rent);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(RentValidator))]
        public IResult Delete(Rent rent)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            _rentDal.Delete(rent);
            return new SuccessResult();
        }

        public IDataResult<List<Rent>> GetAll()
        {
            return new SuccessDataResult<List<Rent>>(_rentDal.GetAll());
        }

        [ValidationAspect(typeof(RentValidator))]
        public IResult Update(Rent rent)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            _rentDal.Update(rent);
            return new SuccessResult();
        }
    }
}
