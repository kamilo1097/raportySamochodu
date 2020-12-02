using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceCar.Models
{
    public class Repairs
    {
        public int Id { get; set; }
        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }
        [Display(Name = "Kilometry (total)")]
        public int Kilometers { get; set; }
        [Display(Name = "Koszt naprawy")]
        public int Cost { get; set; }
        [Display(Name = "Co naprawiano")]
        public string WhatFixed { get; set; }
        [Display(Name = "Kiedy naprawiano")]
        [DataType(DataType.Date)]
        public DateTime WhenFixed { get; set; }
    }
}
