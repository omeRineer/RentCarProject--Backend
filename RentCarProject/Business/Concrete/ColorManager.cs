using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utility.BusinessRules;
using Core.Utility.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            IResult result = BusinessRules.Run();

            if (result!=null)
            {
                return result;
            }
            _colorDal.Add(color);
            return new SuccessResult(Message.ColorAdded);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Delete(Color color)
        {
            IResult result = BusinessRules.Run();

            if (result!=null)
            {
                return result;
            }
            _colorDal.Delete(color);
            return new SuccessResult(Message.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            _colorDal.Update(color);
            return new SuccessResult(Message.ColorUpdated);
        }
    }
}
