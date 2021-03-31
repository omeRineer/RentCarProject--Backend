using Business.Abstract;
using Business.Constans;
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
            var image = _fileHelper.Upload(file, "Image");
            if (image.Success)
            {
                carImage.Date = DateTime.Today;
                carImage.ImagePath = file.FileName;
                _carImageDal.Add(carImage);
                return new SuccessResult(Message.ImageAdded);
            }
            return new ErrorResult();
            
        }

        public IResult Delete(string path,int carImageId)
        {
            var result = _carImageDal.Get(p => p.ImageId == carImageId);
            if (result!=null)
            {
                var fileResult = _fileHelper.Delete(path, result.ImagePath);
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
    }
}
