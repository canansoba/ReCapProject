using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class RentalDetailDto:IDto
    {
        public int Id { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public int DailyPrice { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
       

    }
}
