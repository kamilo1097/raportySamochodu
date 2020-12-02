using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceCar.Models
{
    public class CarDataViewModel
    {
        public Car car { get; set; }
        public double LastFuelConsumption { get; set; }
        public double AverageFuelConsumption { get; set; }
        public double SpendFuelMoney { get; set; }
        [DataType(DataType.Date)]
        public DateTime lastOverview { get; set; }
        public int DaysToNextOverview { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastInsurance { get; internal set; }
        public int DaysToNextInsurance { get; internal set; }
    }
}
