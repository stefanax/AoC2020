using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class Day14
    {
        private InputFiles _inputFiles = new InputFiles();

        private ulong ApplyMask(string mask, ulong value)
        {
            ulong forceOneMask = 0;
            ulong forceZeroMask = 0b_1111_1111_1111_1111_1111_1111_1111_1111_1111;

            ulong fuglyHack = 1;

            for (var i = 0; i < mask.Length; i++)
            {
                switch (mask.Substring(mask.Length-1-i, 1))
                {
                    case "X": break;
                    case "1": forceOneMask += fuglyHack;
                        break;
                    case "0": forceZeroMask -= fuglyHack;
                        break;
                }

                fuglyHack *= 2;
            }
            
            value |= forceOneMask;
            value &= forceZeroMask;

            return value;
        }

        private List<ulong> ApplyMaskToMemoryPos(string mask, ulong inputMemoryPosition)
        {
            Console.WriteLine("Meep 1");
            var memoryPositions = new List<ulong>();

            var memoryPositionsStringsOne = new List<string>();
            var memoryPositionsStringsTwo = new List<string>();

            var inputMemoryPositionAsString = Convert.ToString((long)inputMemoryPosition, 2).PadLeft(mask.Length, '0');

            for (var i = 0; i < inputMemoryPositionAsString.Length; i++)
            {
                switch (mask[i])
                {
                    case '0': break;
                    case '1': inputMemoryPositionAsString = inputMemoryPositionAsString.Substring(0, i) + "1" + (i == inputMemoryPositionAsString.Length-1 ? "" : inputMemoryPositionAsString.Substring(i + 1));
                        break;
                    case 'X': inputMemoryPositionAsString = inputMemoryPositionAsString.Substring(0, i) + "X" + (i == inputMemoryPositionAsString.Length-1 ? "" : inputMemoryPositionAsString.Substring(i + 1));
                        break;
                    
                }
            }
            
            Console.WriteLine("Meep 2");
            
            memoryPositionsStringsOne.Add(inputMemoryPositionAsString);

            for (var i = 0; i < mask.Length; i++)
            {
                foreach (var memoryPositionString in memoryPositionsStringsOne)
                {
                    if (memoryPositionString[i] == 'X')
                    {
                        memoryPositionsStringsTwo.Add(memoryPositionString.Substring(0, i) + "0" + (i == inputMemoryPositionAsString.Length-1 ? "" : inputMemoryPositionAsString.Substring(i + 1)));
                        memoryPositionsStringsTwo.Add(memoryPositionString.Substring(0, i) + "1" + (i == inputMemoryPositionAsString.Length-1 ? "" : inputMemoryPositionAsString.Substring(i + 1)));
                    }
                    else
                    {
                        if (!memoryPositionsStringsTwo.Contains(memoryPositionString))
                        {
                            memoryPositionsStringsTwo.Add(memoryPositionString);
                        }
                    }
                }

                memoryPositionsStringsOne = memoryPositionsStringsTwo;
                memoryPositionsStringsTwo = new List<string>();
                Console.WriteLine($"Meep 2b: {memoryPositionsStringsOne.Count}");
            }
            
            Console.WriteLine("Meep 3");

            foreach (var MemoryPositionString in memoryPositionsStringsOne)
            {
                memoryPositions.Add(Convert.ToUInt64(MemoryPositionString, 2));
            }

            return memoryPositions;
        }
        
        public void Step1()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(14, false));
            var memory = new ulong[100000];

            var mask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";

            foreach (var command in inputList)
            {
                if (command.Substring(0, 4) == "mask")
                {
                    mask = command.Substring(7);
                    continue;
                }

                var memoryPos = Int32.Parse(command.Substring(4, command.IndexOf("]") - 4));
                ulong memoryValue = Convert.ToUInt64(command.Substring(command.IndexOf("=") + 2));
                memory[memoryPos] = ApplyMask(mask, memoryValue);
            }

            ulong memoryTotal = 0;
            foreach (var memoryVal in memory)
            {
                memoryTotal += memoryVal;
            }
            
            Console.WriteLine($"Day 14a result: {memoryTotal}");
        }
        

        public void Step2()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(14, false));
            //var memory = new ulong[10000000000];
            var memory = new Dictionary<ulong, ulong>();

            var mask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";

            foreach (var command in inputList)
            {
                if (command.Substring(0, 4) == "mask")
                {
                    mask = command.Substring(7);
                    continue;
                }

                ulong memoryPos = Convert.ToUInt64(command.Substring(4, command.IndexOf("]") - 4));
                ulong memoryValue = Convert.ToUInt64(command.Substring(command.IndexOf("=") + 2));

                foreach (var newMask in ApplyMaskToMemoryPos(mask, memoryPos))
                {
                    memory[newMask] = memoryValue;
                }
            }

            ulong memoryTotal = 0;
            foreach (var memoryVal in memory)
            {
                memoryTotal += memoryVal.Value;
            }
            
            Console.WriteLine($"Day 14b result: {memoryTotal}");
        }

    }
}