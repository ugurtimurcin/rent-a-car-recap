using Core.Utilities.Results;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<ColorDto>> GetAll();
        IDataResult<ColorDto> GetById(int id);
        IResult Add(ColorDto entity);
        IResult Update(ColorDto entity);
        IResult Delete(ColorDto entity);
    }
}
