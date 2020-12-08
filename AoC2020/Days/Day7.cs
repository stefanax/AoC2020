using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class Day7
    {
        private InputFiles _inputFiles = new InputFiles();
        private List<BagRule> _bagRules = new List<BagRule>();

        public class BagRule
        {
            public string colour { get; set; }
            public Dictionary<string, int> containsBags { get; set; }

            public BagRule()
            {
                containsBags = new Dictionary<string, int>();
            }
        }

        public Day7()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(7, false));
            
            foreach (var rule in inputList)
            {
                var ruleSplit = rule.Split(" ");
                var newRule = new BagRule();
                newRule.colour = ruleSplit[0] + " " + ruleSplit[1];
                
                var rulePos = 4;
                while (ruleSplit.Length > rulePos)
                {
                    if (ruleSplit[rulePos] == "no")
                    {
                        break;
                    }
                    
                    newRule.containsBags.Add(ruleSplit[rulePos+1] + " " + ruleSplit[rulePos+2], Int32.Parse(ruleSplit[rulePos]));
                    rulePos += 4;
                }
                _bagRules.Add(newRule);
            }
        }

        private List<string> FindTopBags(string currentBag)
        {
            var topBags = new List<string>();

            foreach (var bagRule in _bagRules)
            {
                foreach (var bagRuleContainsBag in bagRule.containsBags)
                {
                    if (bagRuleContainsBag.Key == currentBag)
                    {
                        if (!topBags.Contains(bagRule.colour)) topBags.Add(bagRule.colour);
                        var foundTopBags = FindTopBags(bagRule.colour);
                        foreach (var foundTopBag in foundTopBags)
                        {
                            if (!topBags.Contains(foundTopBag)) topBags.Add(foundTopBag);
                        }
                    }
                }
            }

            return topBags.Count > 0 ? topBags : new List<string> {currentBag};
        }

        private int GetBagsInBag(string colour)
        {
            int bags = 1;
            BagRule currentBagRule = new BagRule();

            foreach (var bagRule in _bagRules)
            {
                if (bagRule.colour == colour)
                {
                    currentBagRule = bagRule;
                    break;
                }
            }

            foreach (var containsBag in currentBagRule.containsBags)
            {
                bags += containsBag.Value * GetBagsInBag(containsBag.Key);
            }

            return bags;
        }

        public void Step1()
        {
            List<string> outerBags;
            
            outerBags = FindTopBags("shiny gold");

            Console.WriteLine($"Day 7a result: {outerBags.Count}");
            
        }

        public void Step2()
        {
            var result = GetBagsInBag("shiny gold") - 1;

            Console.WriteLine($"Day 7b result: {result}");
        }
    }
}