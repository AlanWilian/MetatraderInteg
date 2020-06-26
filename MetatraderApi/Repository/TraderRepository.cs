using MetatraderApi.Data;
using MetatraderApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetatraderApi.Repository
{
    public class TraderRepository : ITraderRepository
    {

        private readonly DataContext _context;
        public TraderRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public async Task<List<TbTimeFrameM5>> GetDataM5(string symbol)
        {
            return await _context.TbTimeFrameM5
                 .Where(m => m.Symbol == symbol && m.Date.Minute % 2 == 0)
                 .OrderByDescending(d => d.Date)
                 .Take(2)
                 .ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
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

        public async Task<List<TbTimeFrameM5>> GetCandles(string symbol)
        {
            return await _context.TbTimeFrameM5
                 .Where(m => m.Symbol == symbol)
                 .ToListAsync();
        }

        public async Task<List<MovingAverage>> GetMovingAverage(string symbol)
        {
            return await _context.TbMovingAverage
                 .Where(m => m.Symbol == symbol)
                 .ToListAsync();
        }
    }
}
