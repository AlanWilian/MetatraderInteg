using MetatraderApi.Dto;
using MetatraderApi.Repository;
using System.Linq;
using System.Threading.Tasks;

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

            if (result.Count > 1 && result[0].Date.Minute % 2 != 0)
            {
                data = new UseToCalculateM10Dto
                {
                    Open = result[1].Open,
                    High = result.Max(h => h.High),
                    Low = result.Min(l => l.Low),
                    Close = result[0].Close,
                    Date = result[1].Date,
                    Symbol = symbol
                };
            }

            return data;
        }
    }
}
