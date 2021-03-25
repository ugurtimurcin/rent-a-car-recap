using Core.Utilities.Results;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<BrandDto>> GetAll();
        IDataResult<BrandDto> GetById(int id);
        IResult Add(BrandDto entity);
        IResult Update(BrandDto entity);
        IResult Delete(BrandDto entity);
    }
}
