using Microsoft.EntityFrameworkCore;
using ServiceCar.Data;
using ServiceCar.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceCar.Classes
{
    public class MainClass
    {
        public CarDataViewModel carVM { get; set; } = new CarDataViewModel();
        public CalculateValues calcValues { get; set; } = new CalculateValues();
        public CarServiceContext _context { get; set; }
        public int? _Id { get; set; }
        public MainClass(CarServiceContext context, int? id)
        {
            _context = context;
            _Id = id;
        }
        

        public Car GetFirstCarInfo()
        {   
            return carVM.car = _context.Car.FirstOrDefault(m => m.Id == _Id);
        }
        public void GetLastFuelConsumption()
        {
            var LastFuelConsumption = _context.Fills.OrderByDescending(m => m.Id).FirstOrDefault(m => m.CarId == _Id);
            if(LastFuelConsumption == null)
            {
                carVM.LastFuelConsumption = calcValues.CalculateLastFuelConsumption(0, 0);
            }
            else
            {
                carVM.LastFuelConsumption = calcValues.CalculateLastFuelConsumption(LastFuelConsumption.Litres, LastFuelConsumption.Kilometers);
            }   
        }
        public void GetAverageFuelConsumption()
        {
            var AverageFuelConsumption = _context.Fills.Where(m => m.CarId == _Id);
            carVM.AverageFuelConsumption = calcValues.CalculateAvgFuelConsumption(AverageFuelConsumption);
        }
        public void GetSpendFuelMoney()
        {
            var SpendFuelMoney = _context.Fills.Where(m => m.CarId == _Id).Sum(m => m.Cost);
            carVM.SpendFuelMoney = SpendFuelMoney;
        }
        public void GetLastOverview()
        {
            var LastOverview = _context.Repairs
                .Where(m => m.CarId == _Id)
                .Where(m => m.WhatFixed == "przegląd")
                .OrderByDescending(m => m.Id)
                .Select(m => m.WhenFixed)
                .FirstOrDefault();


            carVM.DaysToNextOverview = calcValues.CountDiffrenceDates(LastOverview);
            carVM.lastOverview = LastOverview;
        }
        public void GetLastInsurance()
        {
            var LastInsurance = _context.Repairs
                .Where(m => m.CarId == _Id)
                .Where(m => m.WhatFixed == "ubezpieczenie")
                .OrderByDescending(m => m.Id)
                .Select(m => m.WhenFixed)
                .FirstOrDefault();

            carVM.DaysToNextInsurance = calcValues.CountDiffrenceDates(LastInsurance);
            carVM.LastInsurance = LastInsurance;
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////
        /// </summary>
        //Uzyskanie i przypisanie zmiennych dla klasy CarDataViewModel
        public void SetCarViewModel()
        {
            GetLastFuelConsumption();
            GetFirstCarInfo();
            GetAverageFuelConsumption();
            GetSpendFuelMoney();
            GetLastOverview();
            GetLastInsurance();
        }
        public CarDataViewModel ReturnCarViewModel()
        {
            SetCarViewModel();
            
            return carVM;
        }
    }
}
