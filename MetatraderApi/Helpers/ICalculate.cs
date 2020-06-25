using MetatraderApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetatraderApi.Helpers
{
    public interface ICalculate
    {
        Task<double> CalcMovingAverage(string symbol, int period);
        Task<double> FindHighestPrice(string symbol, int period);
        Task<double> FindLowestPrice(string symbol, int period);
    }
}
