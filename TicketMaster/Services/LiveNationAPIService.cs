using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Interfaces;
using TicketMaster.Models;
using TicketMaster.Utility;

namespace TicketMaster.Services
{
    public class LiveNationAPIService : ILiveNationAPIService
    {
        private readonly IRuleService ruleService;

        public LiveNationAPIService(IRuleService ruleService)
        {
            this.ruleService = ruleService;
        }

        public Rule AddRule(Rule rule)
        {
            ruleService.AddRule(rule);
            return rule;
        }

        public void DeleteRule(string key)
        {
            ruleService.DeleteRule(key);
        }

        public virtual LiveNationResponse GetLiveNationResponse(string range)
        {
            StringBuilder result = new StringBuilder();
            List<int> ranges = new List<int>();
            List<string> matchedWords = new List<string>();
            if (Utility.Range.isValidRange(range))
            {
                ranges = Utility.Range.GetRange(range);
            }

            var rules = GetRules();
            var keys = rules.Keys;
            Dictionary<string, string> stats = new Dictionary<string, string>();

            foreach (var item in ranges)
            {
                int count = 0;
                bool mapped = false;
                StringBuilder matchedWord = new StringBuilder();
                
                if(result.Length>0)
                {
                    result.Append(" ");
                }

                foreach (var key in keys)
                {
                    count++;
                    if ((item % Convert.ToInt32(key)) == 0)
                    {
                        mapped = true;
                        matchedWord.Append(rules[key]);
                    }

                    if (count == keys.Count)
                    {
                        matchedWords.Add(matchedWord.ToString());
                        result.Append(matchedWord.ToString());
                    }
                }
                if (!mapped)
                {
                    result.Append(item.ToString());
                }
            }

            stats = getWordCountStats(matchedWords);

            var response = new LiveNationResponse() { Result = result.ToString(), Summary = stats };

            return response;
        }

        public Dictionary<string,string> getWordCountStats(List<string> matchedWords)
        {
            Dictionary<string, string> stats = new Dictionary<string, string>();
            foreach (var word in matchedWords.Distinct())
            {
                int count = matchedWords.Where(x => x == word).Count();
                if ((!stats.ContainsKey(word)))
                    stats.Add(word, count.ToString());
            }

            stats.Add("Integer", stats[""]);
            stats.Remove("");

            return stats;
        }

        public Rule GetRule(string key)
        {
            return ruleService.GetRule(key);
        }

        public Dictionary<string, string> GetRules()
        {
            var rules = ruleService.GetRules();
            return rules;
        }

    }
}
