using Core.Utilities.Results;
using Entities;
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
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
        IResult Add(CarImage entity, List<IFormFile> files);
        IResult Update(CarImage entity);
        IResult Delete(CarImage entity);
    }
}
