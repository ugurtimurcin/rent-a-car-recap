using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        private readonly IMapper _mapper;

        public CarManager(ICarDal carDal, IMapper mapper)
        {
            _carDal = carDal;
            _mapper = mapper;
        }

        public IResult Add(CarDto entity)
        {
            _carDal.Add(_mapper.Map<Car>(entity));
            return new SuccessResult();
        }

        public IResult Delete(CarDto entity)
        {
            _carDal.Delete(_mapper.Map<Car>(entity));
            return new SuccessResult();
        }

        public IDataResult<List<CarDto>> GetAll()
        {
            return new SuccessDataResult<List<CarDto>>(_mapper.Map<List<CarDto>>(_carDal.GetAll()));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrand(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(x=>x.BrandId == brandId));
        }

        public IDataResult<CarDto> GetById(int id)
        {
            return new SuccessDataResult<CarDto>(_mapper.Map<CarDto>(_carDal.Get(x => x.Id == id)));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult Update(CarDto entity)
        {
            _carDal.Update(_mapper.Map<Car>(entity));
            return new SuccessResult();
        }

        public IDataResult<CarDetailDto> GetCarDetailById(int id)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailById(id));
        }
    }
}
