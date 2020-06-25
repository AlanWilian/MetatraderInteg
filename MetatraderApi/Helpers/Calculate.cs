using MetatraderApi.Data;
using MetatraderApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetatraderApi.Helpers
{
    public class Calculate : ICalculate
    {

        private readonly DataContext _context;
        public Calculate(DataContext context)
        {
            _context = context;
        }


        public async Task<double> CalcMovingAverage(string symbol, int period)
        {
            return await _context.TbTimeFrameM5
                .Where(m => m.Symbol == symbol)
                .OrderByDescending(d => d.Date)
                .Select(c => c.Close)
                .Take(period)
                .AverageAsync();
        }

        public async Task<double> FindHighestPrice(string symbol, int period)
        {
            return await _context.TbTimeFrameM5
                 .Where(m => m.Symbol == symbol)
                 .OrderByDescending(d => d.Date)
                 .Take(period)
                 .MaxAsync(p => p.High);                 

        }

        public async Task<double> FindLowestPrice(string symbol, int period)
        {
            return await _context.TbTimeFrameM5
                .Where(m => m.Symbol == symbol)
                .OrderByDescending(d => d.Date)
                .Take(period)
                .MinAsync(p => p.Low);
        }
    }
}
