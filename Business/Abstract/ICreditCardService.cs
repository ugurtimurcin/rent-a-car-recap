using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<List<CreditCardDto>> GetAll();
        IDataResult<CreditCardDto> GetById(int id);
        IResult Add(CreditCardDto entity);
        IResult Update(CreditCardDto entity);
        IResult Delete(CreditCardDto entity);
    }
}
