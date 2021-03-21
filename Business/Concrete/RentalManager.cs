using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental entity)
        {
            var result = BusinessRules.Run(CheckIfCarOnRent(entity.CarId));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(x => x.Id == id));
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult();
        }

        private IResult CheckIfCarOnRent(int id)
        {
            var result = _rentalDal.Get(x => x.CarId == id);
            if (result != null)
            {
                return new ErrorResult(Message.CarAlreadyRented);
            }
            return new SuccessResult();
        }
    }
}
