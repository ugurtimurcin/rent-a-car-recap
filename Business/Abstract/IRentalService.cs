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
    public interface IRentalService
    {
        IDataResult<List<RentalDto>> GetAll();
        IDataResult<RentalDto> GetById(int id);
        IResult Add(RentalDto entity);
        IResult Update(RentalDto entity);
        IResult Delete(RentalDto entity);
    }
}
