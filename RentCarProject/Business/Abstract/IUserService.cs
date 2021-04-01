using Core.Entities.Concrete;
using Core.Utility.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        void Add(User user);
        User GetByMail(string email);
        List<OperationClaim> GetClaims(User user);
        
    }
}
