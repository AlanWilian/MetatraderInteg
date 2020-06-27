
using MetatraderApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetatraderApi.Repository
{
    public interface ITraderRepository
    {

        void Add<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IList<TbTimeFrameM5>> GetDataM5(string symbol);
        Task<double> CalcMovingAverage(string symbol, int period);
        Task<double> FindHighestPrice(string symbol, int period);
        Task<double> FindLowestPrice(string symbol, int period);
        Task<IList<TbTimeFrameM5>> GetCandles(string symbol, DateTime start, DateTime end);
        Task<IList<MovingAverage>> GetMovingAverage(string symbol);

    }
}
