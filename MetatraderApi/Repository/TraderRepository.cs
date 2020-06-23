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

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
            
        public async Task<IEnumerable<MetaTraderInfo>> GetCurrency(string symbol, int timeFrame)
        {
            var result = await _context.MetaTraderInfo.Where(m => m.Symbol == symbol).ToListAsync();
            return result;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
