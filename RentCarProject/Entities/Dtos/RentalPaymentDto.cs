using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class RentalPaymentDto:IDto
    {
        public int RentId { get; set; }
        public int Car { get; set; }
        public int Customer { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string CardNumber { get; set; }
        public short CVV { get; set; }
    }
}
