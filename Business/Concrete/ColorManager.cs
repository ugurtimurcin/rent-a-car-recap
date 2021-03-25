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
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;
        private readonly IMapper _mapper;
        public ColorManager(IColorDal colorDal, IMapper mapper)
        {
            _colorDal = colorDal;
            _mapper = mapper;
        }

        public IResult Add(ColorDto entity)
        {
            _colorDal.Add(_mapper.Map<Color>(entity));
            return new SuccessResult();
        }

        public IResult Delete(ColorDto entity)
        {
            _colorDal.Delete(_mapper.Map<Color>(entity));
            return new SuccessResult();
        }

        public IDataResult<List<ColorDto>> GetAll()
        {
            return new SuccessDataResult<List<ColorDto>>(_mapper.Map<List<ColorDto>>(_colorDal.GetAll()));
        }

        public IDataResult<ColorDto> GetById(int id)
        {
            return new SuccessDataResult<ColorDto>(_mapper.Map<ColorDto>(_colorDal.Get(x => x.Id == id)));
        }

        public IResult Update(ColorDto entity)
        {
            _colorDal.Update(_mapper.Map<Color>(entity));
            return new SuccessResult();
        }
    }
}
