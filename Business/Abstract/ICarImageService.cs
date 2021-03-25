using Core.Utilities.Results;
using Entities;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImageDto>> GetAll();
        IDataResult<CarImageDto> GetById(int id);
        IResult Add(CarImageDto entity, List<IFormFile> files);
        IResult Update(CarImageDto entity);
        IResult Delete(CarImageDto entity);
    }
}
