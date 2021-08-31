using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketMaster.Interfaces;
using TicketMaster.Models;

namespace TicketMaster.Services
{
    public class RuleService : IRuleService
    {
        private Dictionary<string, string> _rules;

        public RuleService()
        {
            SeedData();
        }

        public void AddRule(Rule rule)
        {
            if (_rules.ContainsKey(rule.Key))
            {
                _rules[rule.Key] = rule.Value;
            }
            else
            {
                _rules.Add(rule.Key, rule.Value);
            }
        }

        public void DeleteRule(string key)
        {
            if (_rules.ContainsKey(key))
            {
                _rules.Remove(key);
            }
        }

        public Rule GetRule(string key)
        {
            var rule = new Rule() { Key = key, Value = _rules[key] };
            return rule;
        }

        public Dictionary<string, string> GetRules()
        {
            return _rules;
        }

        public void SeedData()
        {
            _rules = new Dictionary<string, string>();
            _rules.Add("3", "Live");
            _rules.Add("5", "Nation");
        }
    }
}
