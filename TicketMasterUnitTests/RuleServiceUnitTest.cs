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
    public class RuleServiceUnitTest
    {
        private readonly Mock<IRuleService> _rule_service;

        public RuleServiceUnitTest()
        {
            _rule_service = new Mock<IRuleService>();
        }

        [Fact]
        public void getRulesReturnValidRules()
        {
            Dictionary<string, string> rules = new Dictionary<string, string>();
            rules.Add("3", "Live");
            rules.Add("5", "Nation");

            _rule_service.Setup(x=>x.GetRules()).Returns(rules);
            Assert.Equal(2, _rule_service.Object.GetRules().Count);
            Assert.Equal(rules, _rule_service.Object.GetRules());
        }

    }
}
