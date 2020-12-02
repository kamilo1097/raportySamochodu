using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceCar.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Display(Name = "Marka")]
        public string Name { get; set; }
        [Display(Name = "Model")]
        public string SubName { get; set; }
        [Display(Name = "Cena za którą kupiono")]
        public int Price { get; set; }
        [Display(Name = "Kiedy kupiono")]
        [DataType(DataType.Date)]
        public DateTime BoughtDate { get; set; }

        public List<Fills> Fills { get; set; }
        public List<Repairs> Repairs { get; set; }
    }
}
