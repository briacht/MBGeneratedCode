using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApp.Models
{
    public class CarModel
    {
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public float Price { get; set; }
    }
}
