using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class Day6
    {
        private InputFiles _inputFiles = new InputFiles();

        public void Step1()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(6, false));

            var total = 0;
            var groupAnswers = new Dictionary<char, bool>();

            foreach (var answers in inputList)
            {
                if (string.IsNullOrEmpty(answers))
                {
                    total += groupAnswers.Count;
                    groupAnswers = new Dictionary<char, bool>();
                    continue;
                }

                foreach (var answer in answers.ToCharArray())
                {
                    groupAnswers.TryAdd(answer, true);
                }
            }

            Console.WriteLine($"Day 6a result: {total}");
        }


        public void Step2()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(6, false));

            var total = 0;
            var groupCount = 0;
            var groupAnswers = new Dictionary<char, int>();

            foreach (var answers in inputList)
            {
                if (string.IsNullOrEmpty(answers))
                {
                    foreach (var groupAnswer in groupAnswers)
                    {
                        if (groupAnswer.Value == groupCount)
                        {
                            total++;
                        }
                    }
                    
                    groupAnswers = new Dictionary<char, int>();
                    groupCount = 0;
                    continue;
                }

                groupCount++;

                foreach (var answer in answers.ToCharArray())
                {
                    if (groupAnswers.ContainsKey(answer))
                    {
                        var currentCount = groupAnswers[answer];
                        groupAnswers[answer] = currentCount+1;
                    }
                    else
                    {
                        groupAnswers.Add(answer, 1);
                    }
                }
            }

            Console.WriteLine($"Day 6b result: {total}");
        }
    }
}