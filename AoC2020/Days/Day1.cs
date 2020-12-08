using System;

namespace AoC2020
{
    public class Day1
    {
        private InputFiles _inputFiles = new InputFiles();

        public void Step1()
        {
            var input = _inputFiles.ReadInputFileForDay(1, false);
            var inputList = _inputFiles.SplitString(input);

            for (var i = 0; i < inputList.Length-1; i++)
            {
                for (var j = i + 1; j < inputList.Length; j++)
                {
                    if (Int32.Parse(inputList[i]) + Int32.Parse(inputList[j]) == 2020)
                    {
                        Console.WriteLine("Day 1a result: " + (Int32.Parse(inputList[i]) * Int32.Parse(inputList[j])));
                    }
                }
            }
        }
        public void Step2()
        {
            var input = _inputFiles.ReadInputFileForDay(1, false);
            var inputList = _inputFiles.SplitString(input);

            for (var i = 0; i < inputList.Length-2; i++)
            {
                for (var j = i + 1; j < inputList.Length-1; j++)
                {
                    for (var k = j + 1; k < inputList.Length; k++)
                    {
                        if (Int32.Parse(inputList[i]) + Int32.Parse(inputList[j]) + Int32.Parse(inputList[k]) == 2020)
                        {
                            Console.WriteLine("Day 1b result: " + (Int32.Parse(inputList[i]) * Int32.Parse(inputList[j]) * Int32.Parse(inputList[k])));
                        }
                    }
                }
            }
        }
    }
}