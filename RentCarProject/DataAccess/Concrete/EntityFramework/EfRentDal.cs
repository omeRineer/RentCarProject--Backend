using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentDal : EfRepositoryBase<RentCarContext, Rent>, IRentDal
    {
        public List<RentDto> GetByRentDto()
        {
            using (RentCarContext carContext=new RentCarContext())
            {
                var result = from x in carContext.Rents

                             join y in carContext.Cars
                             on x.Car equals y.CarId

                             join t in carContext.Brands
                             on y.CarBrand equals t.BrandId

                             join z in carContext.Customers
                             on x.Customer equals z.UserId

                             join u in carContext.Users
                             on z.UserId equals u.UserId

                             select new RentDto
                             {
                                 RentId = x.RentId,
                                 CarBrand = t.BrandName,
                                 Customer = u.UserFirstName + " " + u.UserLastName,
                                 RentDate = x.RentDate,
                                 ReturnDate = x.ReturnDate
                             };
                return result.ToList();

            }
        }
    }
}
