using Core.Utility.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICardService
    {
        IDataResult<Card> GetByCardId(int id);
        IResult Add(Card card);
        IResult Delete(Card card);
        IResult Update(Card card);

        IResult IsCardExist(Card card);

        IResult Pay(Card card);
    }
}
