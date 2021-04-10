using Business.Abstract;
using Business.Constans;
using Core.Utility.BusinessRules;
using Core.Utility.Helpers.FileHelpers;
using Core.Utility.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        
        public CarImageManager(ICarImageDal carImageDal,IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file,CarImage carImage)
        {
            IResult result = BusinessRules.Run();

            var image = _fileHelper.Upload(file, "Image");
            if (image.Success)
            {
                carImage.Date = DateTime.Today;
                carImage.ImagePath = image.Data.Remove(0, 10);
                _carImageDal.Add(carImage);
                return new SuccessResult(Message.ImageAdded);
            }
            return new ErrorResult();
            
        }

        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckAvaiblePicture(carImage.CarImageId));

            if (result==null)
            {
                var picture = _carImageDal.Get(p => p.CarImageId == carImage.CarImageId);
                var fileResult = _fileHelper.Delete(picture.ImagePath);
                _carImageDal.Delete(carImage);
                if (fileResult.Success)
                {
                    return new SuccessResult(Message.ImageDeleted);
                }
            }
            return new ErrorResult(Message.ImageDeletedError);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.Car == carId));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            throw new NotImplementedException();
        }


        private IResult CheckAvaiblePicture(int carImageId)
        {
            var result = _carImageDal.Get(p => p.CarImageId == carImageId);
            if (result!=null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
