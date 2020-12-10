using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class Day10
    {
        private InputFiles _inputFiles = new InputFiles();
        private Int64 _tries = 0;

        public void Step1()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(10, false));
            var adaptors = new List<int>();

            foreach (var inputItem in inputList)
            {
                adaptors.Add(Int32.Parse(inputItem));
            }
            
            adaptors.Add(0);  // Add starting output
            adaptors.Sort();
            adaptors.Add(adaptors[adaptors.Count-1] + 3);  // Add my device

            var changeOne = 0;
            var changeThree = 0;

            for (var i = 1; i < adaptors.Count; i++)
            {
                switch (adaptors[i] - adaptors[i - 1])
                {
                    case 1: changeOne++;
                        break;
                    case 3: changeThree++;
                        break;
                    default: throw new Exception("Bad adaptor!");
                }
            }

            var result = changeOne * changeThree;
            Console.WriteLine($"Day 10a result: {result}");
        }

        private Int64 WalkTheLine(List<int> adaptors, int pos, int previousValue)
        {
            _tries++;
            if (_tries % 1000000000 == 0) Console.WriteLine("Progress: " + _tries / 1000000000); 
            
            if (pos >= adaptors.Count) return 0;
            if (adaptors[pos] > previousValue + 3) return 0;
            if (pos == adaptors.Count - 1) return 1;

            Int64 counter = 0;

            counter += WalkTheLine(adaptors, pos + 1, adaptors[pos]);
            counter += WalkTheLine(adaptors, pos + 2, adaptors[pos]);
            counter += WalkTheLine(adaptors, pos + 3, adaptors[pos]);
            
            return counter;
        }

        public void Step2_old()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(10, false));
            var adaptors = new List<int>();

            foreach (var inputItem in inputList)
            {
                adaptors.Add(Int32.Parse(inputItem));
            }
            
            adaptors.Add(0);  // Add starting output
            adaptors.Sort();
            adaptors.Add(adaptors[adaptors.Count-1] + 3);  // Add my device

            Int64 result = WalkTheLine(adaptors, 0, 0);

            Console.WriteLine($"Day 10b result: {result}");
        }

        public void Step2()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(10, false));
            var adaptors = new List<int>();
            var possibleCount = new List<Int64> { 0, 0, 1 };

            foreach (var inputItem in inputList)
            {
                adaptors.Add(Int32.Parse(inputItem));
            }
            
            adaptors.Add(0);  // Add starting output
            adaptors.Add(0);  // Add starting output
            adaptors.Add(0);  // Add starting output
            adaptors.Sort();
            adaptors.Add(adaptors[adaptors.Count-1] + 3);  // Add my device

            Int64 result = 0;

            for (var i = 3; i < adaptors.Count; i++)
            {
                Int64 tempPossibleCount = 0;
                if (adaptors[i] <= adaptors[i - 3] + 3) tempPossibleCount += possibleCount[i - 3];
                if (adaptors[i] <= adaptors[i - 2] + 3) tempPossibleCount += possibleCount[i - 2];
                if (adaptors[i] <= adaptors[i - 1] + 3) tempPossibleCount += possibleCount[i - 1];
                possibleCount.Add(tempPossibleCount);
            }

            Console.WriteLine($"Day 10b result: {possibleCount[possibleCount.Count-1]}");
        }
    }
}