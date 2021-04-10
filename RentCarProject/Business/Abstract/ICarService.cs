using Core.Utility.Result;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);

        IDataResult<List<CarDto>> GetListByBrandId(int brandId);
        IDataResult<List<CarDto>> GetListByColorId(int colorId);
        IDataResult<List<CarDto>> GetListColorAndBrandId(int colorId, int brandId);
        IDataResult<List<CarDto>> GetByCarId(int id); //Tek elemanlı bir dizi döndürür
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);


        IDataResult<List<CarDto>> GetListByCarDetail();
    }
}
