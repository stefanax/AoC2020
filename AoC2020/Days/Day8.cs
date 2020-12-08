using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class Day8
    {
        private InputFiles _inputFiles = new InputFiles();

        private class Computer
        {
            public List<Tuple<string, int>> program = new List<Tuple<string, int>>();
            public int accumulator = 0;
            public int pointer = 0;

            public void RunStep()
            {
                var currentCommand = program[pointer];

                switch (currentCommand.Item1)
                {
                    case "nop": pointer++;
                        break;
                    case "acc": accumulator += currentCommand.Item2;
                        pointer++;
                        break;
                    case "jmp": pointer += currentCommand.Item2;
                        break;
                    default:
                        throw new Exception("Command not found!!!");
                }
            }
        }

        public void Step1()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(8, false));
            var computer = new Computer();
            foreach (var commandLine in inputList)
            {
                var commandLineSplit = commandLine.Split(" ");
                var command = new Tuple<string, int>(commandLineSplit[0], Int32.Parse(commandLineSplit[1]));
                computer.program.Add(command);
            }
            
            var seenPointers = new List<int>();
            //seenPointers.Add(computer.pointer);
            var lastAccumulator = computer.accumulator;

            while (!seenPointers.Contains(computer.pointer))
            {
                seenPointers.Add(computer.pointer);
                computer.RunStep();
                lastAccumulator = computer.accumulator;
            }
            
            Console.WriteLine($"Day 8a result: {lastAccumulator}");
        }

        public void Step2()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(8, false));
            var instructionCount = inputList.Length;
            var computer = new Computer();
            foreach (var commandLine in inputList)
            {
                var commandLineSplit = commandLine.Split(" ");
                var command = new Tuple<string, int>(commandLineSplit[0], Int32.Parse(commandLineSplit[1]));
                computer.program.Add(command);
            }

            for (var i = 0; i < instructionCount; i++)
            {
                computer.accumulator = 0;
                computer.pointer = 0;
                if (computer.program[i].Item1 == "nop")
                {
                    computer.program[i] = new Tuple<string, int>("jmp", computer.program[i].Item2);
                }
                else if (computer.program[i].Item1 == "jmp")
                {
                    computer.program[i] = new Tuple<string, int>("nop", computer.program[i].Item2);
                }
                else
                {
                    continue;
                }
                
                var seenPointers = new List<int>();
                //seenPointers.Add(computer.pointer);
                var lastAccumulator = computer.accumulator;

                while (!seenPointers.Contains(computer.pointer))
                {
                    seenPointers.Add(computer.pointer);
                    computer.RunStep();
                    lastAccumulator = computer.accumulator;
                    if (computer.pointer > instructionCount || computer.pointer < 0) break;
                    if (computer.pointer == instructionCount)
                    {
                        Console.WriteLine($"Day 8b result: {lastAccumulator}");
                        return;
                    }
                }
            
                // Reset the change!
                if (computer.program[i].Item1 == "nop")
                {
                    computer.program[i] = new Tuple<string, int>("jmp", computer.program[i].Item2);
                }
                else if (computer.program[i].Item1 == "jmp")
                {
                    computer.program[i] = new Tuple<string, int>("nop", computer.program[i].Item2);
                }
                
            }
        }

    }
}