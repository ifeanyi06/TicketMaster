using System;
using Xunit;
using Moq;
using TicketMaster.Services;
using TicketMaster.Interfaces;
using TicketMaster.Models;
using TicketMaster.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;
using System.IO;
using System.Collections.Generic;

namespace TicketMasterUnitTests
{
    public class LiveNationAPIServiceUnitTest
    {
        readonly Mock<ILiveNationAPIService> _api_service;

        public LiveNationAPIServiceUnitTest()
        {

            _api_service = new Mock<ILiveNationAPIService>();
        }

        [Fact]
        public void GetRulesReturnAllRules()
        {
            Dictionary<string, string> rules = new Dictionary<string, string>();
            rules.Add("3", "Live");
            rules.Add("5", "Nation");

            _api_service.Setup(x => x.GetRules()).Returns(rules);
            Assert.Equal(2, _api_service.Object.GetRules().Count);
            Assert.Equal(rules, _api_service.Object.GetRules());
        }


        [Fact]
        public void GetLiveNationResponseReturnsValidResponse()
        {
            LiveNationResponse response = GetResponse();
            _api_service.Setup(x => x.GetLiveNationResponse("1-20")).Returns(response);
            Assert.Equal(response, _api_service.Object.GetLiveNationResponse("1-20"));
        }


        public LiveNationResponse GetResponse()
        {
            var result = "1 2 Live 4 Nation Live 7 8 Live Nation 11 Live 13 14 LiveNation 16 17 Live 19 Nation";
            var summary = new Dictionary<string, string>();
            summary.Add("Live", "5");
            summary.Add("Nation", "3");
            summary.Add("LiveNation", "1");
            summary.Add("Integer", "11");
            LiveNationResponse response = new LiveNationResponse() { Result = result, Summary = summary };
            response.Summary = summary;

            return response;
        }

    }
}
