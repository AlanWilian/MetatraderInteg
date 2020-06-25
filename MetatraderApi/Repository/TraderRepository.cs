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
                 .Where(m => m.Symbol == symbol)
                 .OrderByDescending(d => d.Date)
                 .Skip(1)
                 .Take(2)
                 .ToListAsync();
        }

        public async Task<bool> SaveAll()   
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
