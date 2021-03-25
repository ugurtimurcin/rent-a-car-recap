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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IMapper _mapper;
        public CustomerManager(ICustomerDal customerDal, IMapper mapper)
        {
            _customerDal = customerDal;
            _mapper = mapper;
        }

        public IResult Add(CustomerDto entity)
        {
            _customerDal.Add(_mapper.Map<Customer>(entity));
            return new SuccessResult();
        }

        public IResult Delete(CustomerDto entity)
        {
            _customerDal.Delete(_mapper.Map<Customer>(entity));
            return new SuccessResult();
        }

        public IDataResult<List<CustomerDto>> GetAll()
        {
            return new SuccessDataResult<List<CustomerDto>>(_mapper.Map<List<CustomerDto>>(_customerDal.GetAll()));
        }

        public IDataResult<CustomerDto> GetById(int id)
        {
            return new SuccessDataResult<CustomerDto>(_mapper.Map<CustomerDto>(_customerDal.Get(x => x.Id == id)));
        }

        public IResult Update(CustomerDto entity)
        {
            _customerDal.Update(_mapper.Map<Customer>(entity));
            return new SuccessResult();
        }
    }
}
