using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, MyDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetAllWithDetails()
        {
            using (MyDbContext context = new MyDbContext())
            {

                var result = from rent in context.Rentals
                             join car in context.Product on rent.ProductId equals car.Id
                             // join cl in context.Color on c.ColorId equals cl.ID
                             join br in context.Brand on car.BrandId equals br.Id
                             join user in context.Users on rent.CustomerId equals user.Id
                             select new RentalDetailDto
                             {
                                 
                                 Id = rent.Id,
                                 RentDate = rent.RentDate,
                                 ReturnDate = rent.ReturnDate,
                                 ProductId = rent.ProductId,
                                 ProductName = car.Description,
                                 BrandName = br.BrandName,
                                 DailyPrice = car.DailyPrice,
                                 UserId = user.Id,
                                 UserName = user.FirstName,
                                 UserLastName = user.LastName
                             };
                return result.ToList();
                
            }
            return new List<RentalDetailDto>();
        }
    }
}
