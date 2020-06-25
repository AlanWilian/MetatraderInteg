using AutoMapper;
using MetatraderApi.Data;
using MetatraderApi.Dto;
using MetatraderApi.Helpers;
using MetatraderApi.Models;
using MetatraderApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetatraderApi.Controllers
{

    [Route("[controller]")]
    [ApiController]

    public class MetaTraderController : ControllerBase
    {

        private readonly IMapper _mapper;

        private readonly ITraderRepository _repo;

        private readonly ICalculate _calc;

        public MetaTraderController(IMapper mapper, ITraderRepository repo, ICalculate calc)
        {
            _mapper = mapper;
            _repo = repo;
            _calc = calc;

        }


        [HttpPost("ReceiveCandles/{CandlesData}")]
        public async Task<IActionResult> ReceiveCandles(string CandlesData)
        {
            var candle = JsonConvert.DeserializeObject<UseForGetDataDto>(CandlesData);

            var order = _mapper.Map<TbTimeFrameM5>(candle);

            _repo.Add(order);

            if (!await _repo.SaveAll())
                return BadRequest("Coundt save data");

            return Ok();
        }


        [HttpGet("MovingAverage/{symbol}/{period}")]
        public async Task<IActionResult> MovingAverage(string symbol, int period)
        {

            var result = await _calc.CalcMovingAverage(symbol, period);

            return Ok(result);
        }


        [HttpGet("HighestPrice/{symbol}/{period}")]
        public async Task<IActionResult> HighestPrice(string symbol, int period)
        {
            var result = await _calc.FindHighestPrice(symbol, period);

            return Ok(result);
        }


        [HttpGet("LowestPrice/{symbol}/{period}")]
        public async Task<IActionResult> LowestPrice(string symbol, int period)
        {
            var result = await _calc.FindLowestPrice(symbol, period);


            return Ok(result);
        }


        [HttpGet("CalculateTimeFrameM10/{symbol}")]
        public async Task<IActionResult> CalculateTimeFrameM10(string symbol)
        {
            var result = await _repo.GetDataM5(symbol);
            if (!result.Any())            
                return BadRequest("There are no data in M5 table");

                var high = result.Max(h => h.High);

                var low = result.Min(l => l.Low);

                var date = result.Max(d => d.Date);

                var close = (from i in result
                             let max = result.Max(d => d.Date)
                             where i.Date == max
                             select new { closure = i.Close }).ToList();

                var open = (from i in result
                            let min = result.Min(d => d.Date)
                            where i.Date == min
                            select new { open = i.Open }).ToList();


                UseForGetDataDto data = new UseForGetDataDto
                {
                    Open = open[0].open,
                    High = high,
                    Low = low,
                    Close = close[0].closure,
                    Date = date,
                    Symbol = symbol
                };

                var mapDataM5 = _mapper.Map<TbTimeFrameM5>(data);
                _repo.Add(mapDataM5);

                if (!await _repo.SaveAll())
                    return BadRequest("Coundt save data");

                return Ok();
        }
    }
}
