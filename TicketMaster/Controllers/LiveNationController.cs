using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketMaster.Interfaces;
using TicketMaster.Models;

namespace TicketMaster.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LiveNationController : ControllerBase
    {

        private readonly ILogger<LiveNationController> _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly ILiveNationAPIService _liveNationAPIService;
        private readonly MemoryCacheEntryOptions _cacheOptions;

        public LiveNationController(ILogger<LiveNationController> logger, IMemoryCache memoryCache, ILiveNationAPIService service)
        {
            _logger = logger;
            _memoryCache = memoryCache;
            _liveNationAPIService = service;

            _cacheOptions = new MemoryCacheEntryOptions();
            _cacheOptions.AbsoluteExpiration = DateTime.Now.AddMinutes(1);
            _cacheOptions.SlidingExpiration = TimeSpan.FromMinutes(1);
        }


        [HttpGet("GetRules")]
        public Dictionary<string, string> GetRules()
        {
            return _liveNationAPIService.GetRules();
        }


        [HttpGet("GetRangeMatches")]
        public LiveNationResponse GetRangeLiveNationOutput(string range)
        {

            var response = new LiveNationResponse();
            if (_memoryCache.TryGetValue(range, out response))
            {
                return response;
            }
            else
            {
                response = _liveNationAPIService.GetLiveNationResponse(range);
                _memoryCache.Set(range, response, _cacheOptions);
            }

            return response;
        }

        [HttpGet("AddRule")]
        public IActionResult AddRules(Rule rule)
        {
            return Ok(_liveNationAPIService.AddRule(rule));
        }


    }
}
