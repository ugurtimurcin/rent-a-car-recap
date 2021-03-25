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
    public interface ICarService
    {
        IDataResult<List<CarDto>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<CarDto> GetById(int id);
        IDataResult<CarDetailDto> GetCarDetailById(int id);
        IDataResult<List<CarDetailDto>> GetCarsByBrand(int brandId);
        IResult Add(CarDto entity);
        IResult Update(CarDto entity);
        IResult Delete(CarDto entity);
    }
}
