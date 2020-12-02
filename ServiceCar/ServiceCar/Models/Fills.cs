using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceCar.Models
{
    public class Fills
    {
        public int Id { get; set; }
        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }
        [Display(Name = "Kilometry (tymczasowe)")]
        public int Kilometers { get; set; }
        [Display(Name = "Kwota tankowania (zł) - zaokrąglij")]
        public int Cost { get; set; }
        [Display(Name = "Ile litrów")]
        public double Litres { get; set; }
    }
}
