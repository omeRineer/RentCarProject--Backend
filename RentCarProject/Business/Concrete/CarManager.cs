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
            }
            _carDal.Delete(car);
            return new SuccessResult(Message.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<CarDto>> GetListByCarDetail()
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetListByCarDetail());
        }

        public IDataResult<List<CarDto>> GetListByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetListByCarDetail(p => p.CarBrand == brandId));
        }

        public IDataResult<List<CarDto>> GetListByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetListByCarDetail(p => p.CarColor == colorId));
        }

        public IDataResult<CarDto> GetByCarId(int id)
        {
            return new SuccessDataResult<CarDto>(_carDal.GetIdByCarDetail(id));
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

        public IDataResult<List<CarDto>> GetListColorAndBrandId(int colorId, int brandId)
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetListByCarDetail(p => p.CarColor == colorId & p.CarBrand == brandId));
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == carId));
        }
    }
}
