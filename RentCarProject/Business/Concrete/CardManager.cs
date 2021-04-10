using Business.Abstract;
using Core.Utility.BusinessRules;
using Core.Utility.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CardManager : ICardService
    {
        ICardDal _cardDal;

        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }

        public IResult Add(Card card)
        {
            IResult result = BusinessRules.Run();

            if (result!=null)
            {
                return result;
            }
            _cardDal.Add(card);
            return new SuccessResult("Kredi kartı eklendi");
        }

        public IResult Delete(Card card)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            _cardDal.Delete(card);
            return new SuccessResult("Kredi kartı silindi");
        }

        public IDataResult<Card> GetByCardId(int id)
        {
            var result = _cardDal.Get(p => p.CardId == id);
            return new SuccessDataResult<Card>(result);
        }

        public IResult IsCardExist(Card card)
        {
            var result = _cardDal.Get(p => p.CardNumber == card.CardNumber && p.CVV == card.CVV);
            if (result==null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult Pay(Card card)
        {
            var result = IsCardExist(card);
            if (!result.Success)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult Update(Card card)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            _cardDal.Update(card);
            return new SuccessResult("Kredi kartı güncellendi");
        }
    }
}
