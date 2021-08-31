using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketMaster.Models;

namespace TicketMaster.Interfaces
{
    public interface ILiveNationAPIService
    {
        public LiveNationResponse GetLiveNationResponse(string range);
        public Dictionary<string, string> GetRules();
        public Rule GetRule(string key);
        public Rule AddRule(Rule rule);
        public void DeleteRule(string key);

    }
}
