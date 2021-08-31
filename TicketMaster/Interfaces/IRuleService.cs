using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketMaster.Models;

namespace TicketMaster.Interfaces
{
    public interface IRuleService
    {
        public void SeedData();
        public void AddRule(Rule rule);
        public Rule GetRule(string key);
        public void DeleteRule(string key);

        public Dictionary<string, string> GetRules(); 


    }
}
