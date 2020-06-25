using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetatraderApi.Models
{
    public class TbTimeFrameM10
    {
        public int Id { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public DateTime Date { get; set; }
        public string Symbol { get; set; }

    }
}
