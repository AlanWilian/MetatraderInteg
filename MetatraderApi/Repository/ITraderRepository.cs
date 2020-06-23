
using MetatraderApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetatraderApi.Repository
{
    public interface ITraderRepository
    {

        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<MetaTraderInfo>> GetCurrency(string symbol, int timeFrame);
    }
}
