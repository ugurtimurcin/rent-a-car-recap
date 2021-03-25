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
    public interface ICustomerService
    {
        IDataResult<List<CustomerDto>> GetAll();
        IDataResult<CustomerDto> GetById(int id);
        IResult Add(CustomerDto entity);
        IResult Update(CustomerDto entity);
        IResult Delete(CustomerDto entity);
    }
}
