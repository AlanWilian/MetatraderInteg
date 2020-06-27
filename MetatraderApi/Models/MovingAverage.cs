using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetatraderApi.Models
{
    public class MovingAverage
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public string Symbol { get; set; }
        public int Period { get; set; }
        public DateTime DateInput { get; set; }      


    }
}
