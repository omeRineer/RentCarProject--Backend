using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfRepositoryBase<RentCarContext, User>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (RentCarContext carContext=new RentCarContext())
            {
                var result = from x in carContext.OperationClaims
                             join y in carContext.UserOperationClaims
                             on x.Id equals y.OperationClaimId
                             where y.UserId == user.UserId
                             select new OperationClaim
                             {
                                 Id = x.Id,
                                 Name = x.Name
                             };
                return result.ToList();
            }
        }
    }
}
