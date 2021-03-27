using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CarDto:IDto
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int CarModelYear { get; set; }
        public decimal CarDailyPrice { get; set; }
        public string CarDescription { get; set; }
    }
}
