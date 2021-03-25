using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
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
        private readonly IMapper _mapper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper, IMapper mapper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
            _mapper = mapper;
        }

        public IResult Add(CarImageDto entity, List<IFormFile> files)
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
                _carImageDal.Add(_mapper.Map<CarImage>(new CarImageDto { CarId = entity.CarId, ImagePath = entity.ImagePath }));
            }
            return new SuccessResult();
        }

        public IResult Delete(CarImageDto entity)
        {
            _carImageDal.Delete(_mapper.Map<CarImage>(entity));
            return new SuccessResult();
        }

        public IDataResult<List<CarImageDto>> GetAll()
        {
            return new SuccessDataResult<List<CarImageDto>>(_mapper.Map<List<CarImageDto>>(_carImageDal.GetAll()));
        }

        public IDataResult<CarImageDto> GetById(int id)
        {
            return new SuccessDataResult<CarImageDto>(_mapper.Map<CarImageDto>(_carImageDal.Get(x => x.Id == id)));
        }

        public IResult Update(CarImageDto entity)
        {
            _carImageDal.Update(_mapper.Map<CarImage>(entity));
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
