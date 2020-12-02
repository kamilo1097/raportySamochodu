using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceCar.Models;

namespace ServiceCar.Data
{
    public class CarServiceContext : DbContext
    {
        public CarServiceContext(DbContextOptions<CarServiceContext> options)
            :base(options)
        {

        }
        public DbSet<ServiceCar.Models.Car> Car { get; set; }
        public DbSet<ServiceCar.Models.Fills> Fills { get; set; }
        public DbSet<ServiceCar.Models.Repairs> Repairs { get; set; }
    }
}
