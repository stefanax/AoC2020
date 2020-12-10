using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class Day9
    {
        private InputFiles _inputFiles = new InputFiles();

        private Int64 _firstBadNumber = 0;
        private bool _isTestrun = false;

        public void Step1()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(9, _isTestrun));
            var preambleLength = _isTestrun ? 5 : 25;

            var data = new List<Int64>();
            foreach (var inputLine in inputList)
            {
                data.Add(Int64.Parse(inputLine));
            }

            var dataPos = preambleLength-1; // Minus one because of code in loop
            var foundMatch = true;
            while (foundMatch)
            {
                dataPos++;
                foundMatch = false;
                for (var i = dataPos - preambleLength; i < dataPos-1; i++)
                {
                    for (var j = i + 1; j < dataPos; j++)
                    {
                        if (data[i] + data[j] == data[dataPos]) foundMatch = true;
                    }
                }
            }

            _firstBadNumber = data[dataPos];
            
            Console.WriteLine($"Day 9a result: {data[dataPos]}");
        }
        
        public void Step2()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(9, _isTestrun));
            var data = new List<Int64>();
            foreach (var inputLine in inputList)
            {
                data.Add(Int64.Parse(inputLine));
            }

            var dataPos = 0;

            var rangeFound = false;

            while (!rangeFound)
            {
                var searchDataPos = dataPos;
                Int64 searchSum = 0;
                Int64 smallestNumber = 999999999999;
                Int64 largestNumber = 0;
                while (searchSum < _firstBadNumber)
                {
                    searchSum += data[searchDataPos];
                    if (data[searchDataPos] < smallestNumber) smallestNumber = data[searchDataPos];
                    if (data[searchDataPos] > largestNumber) largestNumber = data[searchDataPos];
                    
                    if (searchSum == _firstBadNumber)
                    {
                        var result = smallestNumber + largestNumber;
                        Console.WriteLine($"Day 9b result: {result}");
                        rangeFound = true;
                        break;
                    }

                    searchDataPos++;
                }

                dataPos++;
            }
        }
    }
}