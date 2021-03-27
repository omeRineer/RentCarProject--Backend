using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utility.BusinessRules;
using Core.Utility.Interceptors;
using Core.Utility.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run();

            if (result!=null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Message.CarAdded);

        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
            IResult result = BusinessRules.Run();

            if (result!=null)
            {
                return result;
            }_carDal.Delete(car);
            return new SuccessResult(Message.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<CarDto>> GetAllByCarDetail()
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetByCarDetail());
        }

        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.CarBrand == brandId));
        }

        public IDataResult<List<Car>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.CarColor == colorId));
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == id));
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            IResult result = BusinessRules.Run();

            if (result!=null)
            {
                return result;
            }
            _carDal.Update(car);
            return new SuccessResult(Message.CarUpdated);
        }
    }
}
