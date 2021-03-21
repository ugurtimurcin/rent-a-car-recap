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
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<Car> GetById(int id);
        IDataResult<CarDetailDto> GetCarDetailById(int id);
        IDataResult<List<CarDetailDto>> GetCarsByBrand(int brandId);
        IResult Add(Car entity);
        IResult Update(Car entity);
        IResult Delete(Car entity);
    }
}
