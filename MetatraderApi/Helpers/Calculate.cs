using MetatraderApi.Dto;
using MetatraderApi.Repository;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MetatraderApi.Helpers
{
    public class Calculate : ICalculate
    {

        private readonly ITraderRepository _repo;
        public Calculate(ITraderRepository repo)
        {
            _repo = repo;
        }


        public async Task<UseToCalculateM10Dto> CalculateTimeFrameM10(string symbol)
        {
            UseToCalculateM10Dto data = new UseToCalculateM10Dto();
            var result = await _repo.GetDataM5(symbol);
            //if (result.Count > 1)
            //{

                //var close = (from i in result
                //             let max = result.Max(d => d.Date)
                //             where i.Date == max
                //             select new { closure = i.Close }).ToList();

                //var open = (from i in result
                //            let min = result.Min(d => d.Date)
                //            where i.Date == min
                //            select new { open = i.Open }).ToList();


                data = new UseToCalculateM10Dto
                {
                    Open = result[0].Open,
                    High = result.Max(h => h.High),
                    Low = result.Min(l => l.Low),
                    Close = result[1].Close,
                    Date = result.Max(d => d.Date),
                    Symbol = symbol
                };
            //}
            return data;
        }
    }
}
