
using MetatraderApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetatraderApi.Repository
{
    public interface ITraderRepository
    {

        void Add<T>(T entity) where T : class;
        Task<List<TbTimeFrameM5>> GetDataM5(string symbol);
        Task<bool> SaveAll();

    }
}
