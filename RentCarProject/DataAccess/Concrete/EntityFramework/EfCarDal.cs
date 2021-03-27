using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfRepositoryBase<RentCarContext, Car>, ICarDal
    {
        public List<CarDto> GetByCarDetail()
        {
            using (RentCarContext context=new RentCarContext())
            {
                var result = from x in context.Cars
                             join y in context.Brands
                             on x.CarBrand equals y.BrandId
                             join z in context.Colors
                             on x.CarColor equals z.ColorId
                             select new CarDto
                             {
                                 CarId = x.CarId,
                                 Brand = y.BrandName,
                                 Color = z.ColorName,
                                 CarModelYear = x.CarModelYear,
                                 CarDailyPrice = x.CarDailyPrice,
                                 CarDescription = x.CarDescription
                             };
                return result.ToList();
            }
        }
    }
}
