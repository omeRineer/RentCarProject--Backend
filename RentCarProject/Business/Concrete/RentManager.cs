using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utility.BusinessRules;
using Core.Utility.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business.Concrete
{
    public class RentManager : IRentService
    {
        IRentDal _rentDal;
        ICardService _cardService;

        public RentManager(IRentDal rentDal,ICardService cardService)
        {
            _rentDal = rentDal;
            _cardService = cardService;
        }

        [ValidationAspect(typeof(RentValidator))]
        public IResult Add(RentalPaymentDto rentalPaymentDto)
        {
            IResult result = BusinessRules.Run(CheckIfRentExist(rentalPaymentDto.Car));

            if (result != null)
            {
                return result;
            }

            var cardExist = _cardService.IsCardExist(new Card { CardNumber = rentalPaymentDto.CardNumber, CVV = rentalPaymentDto.CVV });
            if (!cardExist.Success)
            {
                return cardExist;
            }

            _rentDal.Add(new Rent
            {
                Car=rentalPaymentDto.Car,
                Customer=rentalPaymentDto.Customer,
                RentDate=rentalPaymentDto.RentDate,
                ReturnDate=rentalPaymentDto.ReturnDate
            });
            return new SuccessResult();
        }

        [ValidationAspect(typeof(RentValidator))]
        public IResult Delete(Rent rent)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            _rentDal.Delete(rent);
            return new SuccessResult();
        }

        public IDataResult<List<Rent>> GetAll()
        {
            return new SuccessDataResult<List<Rent>>(_rentDal.GetAll());
        }

        public IDataResult<List<RentDto>> GetRentByDto()
        {
            return new SuccessDataResult<List<RentDto>>(_rentDal.GetByRentDto());
        }

        [ValidationAspect(typeof(RentValidator))]
        public IResult Update(Rent rent)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            _rentDal.Update(rent);
            return new SuccessResult();
        }

        private IResult CheckIfRentExist(int carId)
        {
            var result = _rentDal.Get(p => p.Car == carId);
            if (result!=null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
