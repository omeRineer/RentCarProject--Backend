using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class CarImage:IEntity
    {
        public int CarImageId { get; set; }
        public int Car { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
