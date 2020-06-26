using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetatraderApi.Dto
{
    public class UseToSavePriceDto
    {
        public double Value { get; set; }
        public string Symbol { get; set; }
        public int Period { get; set; }
        public string HighOrLow { get; set; }
    }
}
