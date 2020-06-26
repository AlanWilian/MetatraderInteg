
using MetatraderApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetatraderApi.Repository
{
    public interface ITraderRepository
    {

        void Add<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<List<TbTimeFrameM5>> GetDataM5(string symbol);
        Task<double> CalcMovingAverage(string symbol, int period);
        Task<double> FindHighestPrice(string symbol, int period);
        Task<double> FindLowestPrice(string symbol, int period);
        Task<List<TbTimeFrameM5>> GetCandles(string symbol);
        Task<List<MovingAverage>> GetMovingAverage(string symbol);

    }
}
