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
    public class CreditCardManager : ICreditCardService
    {
        private readonly ICreditCardDal _creditCardDal;
        private readonly IMapper _mapper;
        public CreditCardManager(ICreditCardDal creditCardDal, IMapper mapper)
        {
            _creditCardDal = creditCardDal;
            _mapper = mapper;
        }

        public IResult Add(CreditCardDto entity)
        {
            _creditCardDal.Add(_mapper.Map<CreditCard>(entity));
            return new SuccessResult();
        }

        public IResult Delete(CreditCardDto entity)
        {
            _creditCardDal.Delete(_mapper.Map<CreditCard>(entity));
            return new SuccessResult();
        }

        public IDataResult<List<CreditCardDto>> GetAll()
        {
            return new SuccessDataResult<List<CreditCardDto>>(_mapper.Map<List<CreditCardDto>>(_creditCardDal.GetAll()));
        }

        public IDataResult<CreditCardDto> GetById(int id)
        {
            return new SuccessDataResult<CreditCardDto>(_mapper.Map<CreditCardDto>(_creditCardDal.Get(x=>x.Id == id)));
        }

        public IResult Update(CreditCardDto entity)
        {
            _creditCardDal.Update(_mapper.Map<CreditCard>(entity));
            return new SuccessResult();
        }
    }
}
