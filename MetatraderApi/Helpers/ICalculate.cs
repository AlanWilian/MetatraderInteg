using MetatraderApi.Dto;
using MetatraderApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetatraderApi.Helpers
{
    public interface ICalculate
    {
        Task<UseToCalculateM10Dto> CalculateTimeFrameM10(string symbol); 
    }
}
