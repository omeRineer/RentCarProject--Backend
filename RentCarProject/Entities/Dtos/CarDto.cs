using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CarDto:IDto
    {
        public int CarId { get; set; }
        public int CarBrand { get; set; }
        public int CarColor { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int CarModelYear { get; set; }
        public decimal CarDailyPrice { get; set; }
        public string CarDescription { get; set; }
        public string ImagePath { get; set; }
    }
}
