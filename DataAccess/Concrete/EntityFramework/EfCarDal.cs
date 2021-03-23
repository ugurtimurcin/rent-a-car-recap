using Core.DataAccess.EntityFramwork;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfRepositoryBase<Car, DataContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> predicate = null)
        {
            using var context = new DataContext();
            var result = from car in context.Cars
                         join brand in context.Brands on car.BrandId equals brand.Id
                         join color in context.Colors on car.ColorId equals color.Id
                         select new CarDetailDto
                         {
                             Id = car.Id,
                             BrandId = brand.Id,
                             Brand = brand.Name,
                             Color = color.Name,
                             CarName = car.CarName,
                             DailyPrice = car.DailyPrice,
                             Description = car.Description,
                             ModelYear = car.ModelYear,
                             ImagePath = (from image in context.CarImages
                                          where car.Id == image.CarId
                                          select new CarImage 
                                          { 
                                              Id = image.Id, 
                                              CarId = image.CarId, 
                                              Date = image.Date, 
                                              ImagePath = image.ImagePath 
                                          }).ToArray()
                         };

            return predicate == null ? result.ToList() : result.Where(predicate).ToList();

        }

        public CarDetailDto GetCarDetailById(int id)
        {
            using var context = new DataContext();
            var result = from car in context.Cars
                         join brand in context.Brands on car.BrandId equals brand.Id
                         join color in context.Colors on car.ColorId equals color.Id
                         select new CarDetailDto
                         {
                             Id = car.Id,
                             BrandId = brand.Id,
                             Brand = brand.Name,
                             Color = color.Name,
                             CarName = car.CarName,
                             DailyPrice = car.DailyPrice,
                             Description = car.Description,
                             ModelYear = car.ModelYear,
                             ImagePath = (from image in context.CarImages
                                          where car.Id == image.CarId
                                          select new CarImage
                                          {
                                              Id = image.Id,
                                              CarId = image.CarId,
                                              Date = image.Date,
                                              ImagePath = image.ImagePath
                                          }).ToArray()
                         };
            return result.Where(x => x.Id == id).SingleOrDefault();
        }
    }
}
