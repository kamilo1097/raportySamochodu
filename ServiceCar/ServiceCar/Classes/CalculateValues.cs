using ServiceCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceCar.Classes
{
    public class CalculateValues
    {
        public double CalculateLastFuelConsumption(double litres, double kilometers)
        {
            if(litres == 0 || kilometers == 0)
            {
                return 0;
            }
            else
            {
                return (litres / kilometers) * 100;
            }
            
        }
        public double CalculateAvgFuelConsumption(IQueryable<Fills> allRows)
        {
            List<double> items = new List<double>();
            if(allRows == null)
            {
                return 0;
            }
            foreach (var item in allRows)
            {
                items.Add(CalculateLastFuelConsumption(item.Litres, item.Kilometers));
            }
            return items.Sum() / items.Count;

        }
        public int CountDiffrenceDates(DateTime date)
        {
            var oneyearLater = date.AddMonths(12);
            var daysLeft = oneyearLater.Subtract(DateTime.Today).Days;
            return daysLeft;
        }
    }
}
