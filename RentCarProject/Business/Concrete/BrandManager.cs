using Business.Abstract;
using Business.Constans;
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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            IResult result = BusinessRules.Run();

            if (result!=null)
            {
                return result;
            }
            _brandDal.Add(brand);
            return new SuccessResult(Message.BrandAdded);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Delete(Brand brand)
        {
            IResult result = BusinessRules.Run();

            if (result!=null)
            {
                return result;
            }
            _brandDal.Delete(brand);
            return new SuccessResult(Message.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int brandId)
        {
           return new SuccessDataResult<Brand>(_brandDal.Get(p => p.BrandId == brandId));
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            IResult result = BusinessRules.Run();

            if (result!=null)
            {
                return result;
            }
            _brandDal.Update(brand);
            return new SuccessResult(Message.BrandUpdated);
        }
    }
}
