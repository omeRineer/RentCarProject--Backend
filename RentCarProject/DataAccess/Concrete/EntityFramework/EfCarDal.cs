using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.Dtos;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfRepositoryBase<RentCarContext, Car>, ICarDal
    {
        public CarDto GetIdByCarDetail(int carId)
        {
            using (RentCarContext context=new RentCarContext())
            {
                var result = (from x in context.Cars
                              where x.CarId==carId
                              join y in context.Brands
                              on x.CarBrand equals y.BrandId
                              join z in context.Colors
                              on x.CarColor equals z.ColorId
                              select new CarDto
                              {
                                  CarId = x.CarId,
                                  CarBrand = x.CarBrand,
                                  CarColor = x.CarColor,
                                  BrandName = y.BrandName,
                                  ColorName = z.ColorName,
                                  CarModelYear = x.CarModelYear,
                                  CarDailyPrice = x.CarDailyPrice,
                                  CarDescription = x.CarDescription,
                                  ImagePath = (from image in context.CarImages
                                               where image.Car == x.CarId
                                               select image.ImagePath).FirstOrDefault()
                              }).FirstOrDefault();

                return result;
            }
        }

        public List<CarDto> GetListByCarDetail(Expression<Func<Car, bool>> filter = null)
        {
            using (RentCarContext context=new RentCarContext())
            {
                var result = (from x in filter is null ? context.Cars : context.Cars.Where(filter)
                              join y in context.Brands
                              on x.CarBrand equals y.BrandId
                              join z in context.Colors
                              on x.CarColor equals z.ColorId
                              select new CarDto
                              {
                                  CarId = x.CarId,
                                  CarBrand = x.CarBrand,
                                  CarColor = x.CarColor,
                                  BrandName = y.BrandName,
                                  ColorName = z.ColorName,
                                  CarModelYear = x.CarModelYear,
                                  CarDailyPrice = x.CarDailyPrice,
                                  CarDescription = x.CarDescription,
                                  ImagePath = (from image in context.CarImages
                                               where image.Car == x.CarId
                                               select image.ImagePath).FirstOrDefault()
                              });
                return result.ToList();   
            }
        }
    }
}
