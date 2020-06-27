using AutoMapper;
using MetatraderApi.Dto;
using MetatraderApi.Helpers;
using MetatraderApi.Models;
using MetatraderApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MetatraderApi.Data;
using System;

namespace MetatraderApi.Controllers
{

    [AllowAnonymous]
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

            var dataToSave = await _calc.CalculateTimeFrameM10(order.Symbol);

            if (!string.IsNullOrEmpty(dataToSave.Symbol))
                await SaveTimeFrameM10(dataToSave);

            return Ok();
        }

        public async Task<IActionResult> SaveTimeFrameM10(UseToCalculateM10Dto data)
        {
            var mapDataM10 = _mapper.Map<TbTimeFrameM10>(data);
            _repo.Add(mapDataM10);

            if (!await _repo.SaveAll())
                return BadRequest("Coundt save data");

            return Ok();
        }


        [HttpGet("MovingAverage/{symbol}/{period}")]
        public async Task<IActionResult> MovingAverage(string symbol, int period)
        {
            var result = await _repo.CalcMovingAverage(symbol, period);

            UseToSaveMovingAverangeDto dataSaveMovingAverange = new UseToSaveMovingAverangeDto()
            {
                Value = result,
                Symbol = symbol,
                Period = period
        };

            var movingAverange = _mapper.Map<MovingAverage>(dataSaveMovingAverange);

            _repo.Add(movingAverange);

            if (!await _repo.SaveAll())
                return BadRequest("Coundt save");

            return Ok(result);
        }


        [HttpGet("HighestPrice/{symbol}/{period}")]
        public async Task<IActionResult> HighestPrice(string symbol, int period)
        {
            var result = await _repo.FindHighestPrice(symbol, period);

            UseToSavePriceDto dataSavePrice = new UseToSavePriceDto()
            {
                Value = result,
                Symbol = symbol,
                Period = period,
                HighOrLow = "Highest"
            };

            var highestPrice = _mapper.Map<PriceIndicator>(dataSavePrice);

            _repo.Add(highestPrice);

            if (!await _repo.SaveAll())
                return BadRequest("Coundt save");

            return Ok(result);
        }


        [HttpGet("LowestPrice/{symbol}/{period}")]
        public async Task<IActionResult> LowestPrice(string symbol, int period)
        {
            var result = await _repo.FindLowestPrice(symbol, period);

            UseToSavePriceDto dataSavePrice = new UseToSavePriceDto()
            {
                Value = result, 
                Symbol = symbol,
                Period = period,
                HighOrLow = "Lower"
            };

            var lowestPrice = _mapper.Map<PriceIndicator>(dataSavePrice);

            _repo.Add(lowestPrice);

            if (!await _repo.SaveAll())
                return BadRequest("Coundt save");

            return Ok(result);

        }


        [HttpGet("GetCandles/{symbol}/{period}")]
        public async Task<IActionResult> GetCandles(string symbol, DateTime start, DateTime end)
        {
            var candles = await _repo.GetCandles(symbol, start, end);

            if (candles.Any())
                return Ok(candles);

            return BadRequest("there are no candles");
        }


        [HttpGet("GetMovingAverage/{symbol}/{period}")]
        public async Task<IActionResult> GetMovingAverage(string symbol, int period)
        {
            var indicator = await _repo.GetMovingAverage(symbol);

            if (indicator.Any())
                return Ok(indicator);

            return BadRequest("there are no idicator");
        }

    }
}
