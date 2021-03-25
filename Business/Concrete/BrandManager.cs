using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
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
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        private readonly IMapper _mapper;

        public BrandManager(IBrandDal brandDal, IMapper mapper)
        {
            _brandDal = brandDal;
            _mapper = mapper;
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(BrandDto entity)
        {
            _brandDal.Add(_mapper.Map<Brand>(entity));
            return new SuccessResult();
        }

        public IResult Delete(BrandDto entity)
        {
            _brandDal.Delete(_mapper.Map<Brand>(entity));
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<BrandDto>> GetAll()
        {
            return new SuccessDataResult<List<BrandDto>>(_mapper.Map<List<BrandDto>>(_brandDal.GetAll()));
        }

        [CacheAspect]
        public IDataResult<BrandDto> GetById(int id)
        {
            return new SuccessDataResult<BrandDto>(_mapper.Map<BrandDto>(_brandDal.Get(x => x.Id == id)));
        }

        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(BrandDto entity)
        {
            _brandDal.Update(_mapper.Map<Brand>(entity));
            return new SuccessResult();
        }
    }
}
