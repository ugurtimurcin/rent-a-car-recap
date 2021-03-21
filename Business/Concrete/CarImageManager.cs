using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;
        private readonly IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(CarImage entity, List<IFormFile> files)
        {
            var result = BusinessRules.Run(CheckImageCount(entity.CarId));
            if (result != null)
            {
                return result;
            }
            foreach (var file in files)
            {
                entity.ImagePath = Guid.NewGuid() + Path.GetExtension(file.FileName);
                _fileHelper.Upload(entity.ImagePath, file);
                _carImageDal.Add(new CarImage {CarId = entity.CarId, ImagePath = entity.ImagePath });
            }
            return new SuccessResult();
        }

        public IResult Delete(CarImage entity)
        {
            _carImageDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(x => x.Id == id));
        }

        public IResult Update(CarImage entity)
        {
            _carImageDal.Update(entity);
            return new SuccessResult();
        }

        private IResult CheckImageCount(int id)
        {
            var count = _carImageDal.GetAll(x => x.CarId == id).Count;
            if (count > 5)
            {
                return new ErrorResult(Message.CarImageCountOverLimit);
            }
            return new SuccessResult();
        }
    }
}
