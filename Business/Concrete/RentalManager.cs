using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        //IRentalService _rentalService;
        IRentalDal _rentaldal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentaldal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            var result = _rentaldal.GetAll(r => r.Id == rental.Id);
            foreach(var rentals in result)
            {
                if (rentals.ReturnDate == null || rentals.RentDate > rentals.ReturnDate)
                {
                    return new ErrorResult(Messages.CarNotRented);
                }
            }
            _rentaldal.Add(rental);
            return new SuccessResult(Messages.CarRented);
          
        }

        public IResult Delete(Rental rental)
        {
            _rentaldal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentaldal.GetAll());
        }

        public IDataResult<List<RentalDetailDto>> GetAllWithDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentaldal.GetAllWithDetails());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentaldal.Get(r => r.Id == rentalId));
        }

        public IResult Update(Rental rental)
        {
            _rentaldal.Update(rental);
            return new SuccessResult();
        }
    }
}
