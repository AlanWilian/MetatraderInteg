using AutoMapper;
using MetatraderApi.Dto;
using MetatraderApi.Models;
using MetatraderApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MetatraderApi.Controllers
{
    [AllowAnonymous]  
    //[ServiceFilter(typeof(LogUserActivity))]
    [Route("[controller]")]
    [ApiController]

    public class MetaTraderController : ControllerBase
    {

        private readonly IMapper _mapper;

        private readonly ITraderRepository _repo;
        public MetaTraderController(IMapper mapper, ITraderRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }


        [HttpPost("SaveCandles/{CandlesData}")]
        public async Task<IActionResult> SaveCandles(string CandlesData)
        {
            var candle = JsonConvert.DeserializeObject<UseForGetDataDto>(CandlesData);
     
            var Order = _mapper.Map<MetaTraderInfo>(candle);

            _repo.Add(Order);

            if (!await _repo.SaveAll())
                return BadRequest("Erro ao criar ordem");

            return Ok();
        }


        [HttpPost("GetCandles/{symbol}/{timeFrame}")]
        public async Task<IActionResult> GetCandles(string symbol, int timeFrame)
        {

            var candles = await _repo.GetCurrency(symbol, timeFrame);

           // _repo.Add(Order);

            if (!await _repo.SaveAll())
                return BadRequest("Erro ao criar ordem");

            return Ok();
        }




    }
}
