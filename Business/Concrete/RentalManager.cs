using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;
        private readonly IMapper _mapper;
        public RentalManager(IRentalDal rentalDal, IMapper mapper)
        {
            _rentalDal = rentalDal;
            _mapper = mapper;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(RentalDto entity)
        {
            var result = BusinessRules.Run(CheckIsCarAvailable(entity.CarId, entity.RentDate));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(_mapper.Map<Rental>(entity));
            return new SuccessResult();
        }

        public IResult Delete(RentalDto entity)
        {
            _rentalDal.Delete(_mapper.Map<Rental>(entity));
            return new SuccessResult();
        }

        public IDataResult<List<RentalDto>> GetAll()
        {
            return new SuccessDataResult<List<RentalDto>>(_mapper.Map<List<RentalDto>>(_rentalDal.GetAll()));
        }

        public IDataResult<RentalDto> GetById(int id)
        {
            return new SuccessDataResult<RentalDto>(_mapper.Map<RentalDto>(_rentalDal.Get(x => x.Id == id)));
        }

        public IResult Update(RentalDto entity)
        {
            _rentalDal.Update(_mapper.Map<Rental>(entity));
            return new SuccessResult();
        }

        private IResult CheckIsCarAvailable(int id, DateTime? date)
        {
            var car = _rentalDal.Get(x => x.Id == id);
            if (car.ReturnDate == null || car.ReturnDate >= date )
            {
                return new ErrorResult(Message.CarIsOnRent);
            }

            return new SuccessResult();
        }
    }
}
