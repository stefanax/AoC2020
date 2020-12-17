using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class Day15
    {
        private InputFiles _inputFiles = new InputFiles();

        public void Step1()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(15, false))[0].Split(",");

            var numbersSpoken = new Dictionary<string, int>();

            var turnCounter = 1;
            var lastNumberSpoken = "";
            foreach (var inputNumber in inputList)
            {
                numbersSpoken.Add(inputNumber, turnCounter);
                lastNumberSpoken = inputNumber;
                turnCounter++;
            }

            numbersSpoken.Remove(lastNumberSpoken);  // We don't want to store the number yet as that overwrites things...

            while (turnCounter <= 2020)
            {
                if (!numbersSpoken.ContainsKey(lastNumberSpoken))
                {
                    numbersSpoken.Add(lastNumberSpoken, turnCounter-1);
                    lastNumberSpoken = "0";
                }
                else
                {
                    var timeDiff = turnCounter - 1 - numbersSpoken[lastNumberSpoken];
                    numbersSpoken[lastNumberSpoken] = turnCounter - 1;
                    lastNumberSpoken = timeDiff.ToString();
                }

                turnCounter++;
            }
            
            Console.WriteLine($"Day 15a result: {lastNumberSpoken}");
        }

        public void Step2()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(15, false))[0].Split(",");

            var numbersSpoken = new Dictionary<string, int>();

            var turnCounter = 1;
            var lastNumberSpoken = "";
            foreach (var inputNumber in inputList)
            {
                numbersSpoken.Add(inputNumber, turnCounter);
                lastNumberSpoken = inputNumber;
                turnCounter++;
            }

            numbersSpoken.Remove(lastNumberSpoken);  // We don't want to store the number yet as that overwrites things...

            while (turnCounter <= 30000000)
            {
                if (!numbersSpoken.ContainsKey(lastNumberSpoken))
                {
                    numbersSpoken.Add(lastNumberSpoken, turnCounter-1);
                    lastNumberSpoken = "0";
                }
                else
                {
                    var timeDiff = turnCounter - 1 - numbersSpoken[lastNumberSpoken];
                    numbersSpoken[lastNumberSpoken] = turnCounter - 1;
                    lastNumberSpoken = timeDiff.ToString();
                }

                turnCounter++;
            }
            
            Console.WriteLine($"Day 15b result: {lastNumberSpoken}");
        }
    }
}