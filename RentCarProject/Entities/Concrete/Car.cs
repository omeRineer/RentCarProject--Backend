using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int CarId { get; set; }
        public int CarBrand { get; set; }
        public int CarColor { get; set; }
        public int CarModelYear { get; set; }
        public decimal CarDailyPrice { get; set; }
        public string CarDescription { get; set; }
    }
}
