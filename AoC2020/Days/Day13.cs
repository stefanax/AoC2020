using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class Day13
    {
        private InputFiles _inputFiles = new InputFiles();

        public void Step1()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(13, false));

            var startTime = Int32.Parse(inputList[0]);
            var currentTime = startTime;
            var busses = new List<int>();

            foreach (var busAsString in inputList[1].Split(","))
            {
                if (busAsString == "x") continue;
                busses.Add(Int32.Parse(busAsString));
            }

            var foundBusId = -1;
            while (foundBusId == -1)
            {
                foreach (var bus in busses)
                {
                    if (currentTime % bus == 0)
                    {
                        foundBusId = bus;
                        break;
                    }
                }

                currentTime++;
            }

            currentTime--; // Fix as we shoulnd't increment when we find a bus that works


            var result = (currentTime - startTime) * foundBusId;
            
            Console.WriteLine($"Day 13a result: {result}");
        }

        public void Step2()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(13, false));
            
            var busses = new List<int>();

            var highestBusId = -1;
            var highestBusIdPos = -1;

            var tempPos = 0;
            foreach (var busAsString in inputList[1].Split(","))
            {
                if (busAsString == "x")
                {
                    busses.Add(-1);
                }
                else
                {
                    var tempBusId = Int32.Parse(busAsString);
                    busses.Add(tempBusId);
                    if (tempBusId > highestBusId)
                    {
                        highestBusId = tempBusId;
                        highestBusIdPos = tempPos;
                    }
                }

                tempPos++;
            }

            long currentTime = 0; // 100000000000000;  //NOTE: Not compatible with test input!
            long incrementByAmount = 1; // highestBusId;

            // while ((currentTime + highestBusIdPos) % highestBusId != 0)
            // {
            //     currentTime++;
            // }

            var foundAmount = 0;
            var foundFirstNew = false;
            var lastFoundTimeAtSameAmount = currentTime;

            var foundTimestamp = false;
            while (!foundTimestamp)
            {
                currentTime += incrementByAmount;

                var busMismatch = false;
                var tempFoundAmount = 0;
                for (var i = 0; i < busses.Count; i++)
                {
                    if (busses[i] == -1) continue;
                    if ((currentTime + i) % busses[i] != 0) {
                        busMismatch = true;
                        break;
                    }

                    tempFoundAmount++;
                    if (tempFoundAmount == foundAmount+1)
                    {
                        if (!foundFirstNew)
                        {
                            lastFoundTimeAtSameAmount = currentTime;
                            foundFirstNew = true;
                        }
                        else
                        {
                            foundAmount = tempFoundAmount;
                            if (incrementByAmount < currentTime - lastFoundTimeAtSameAmount)
                            {
                                incrementByAmount = currentTime - lastFoundTimeAtSameAmount;
                            }
                            foundFirstNew = false;
                        }
                    }
                }
                
                if (currentTime % 1000000000 <= incrementByAmount) Console.WriteLine($"Current time: {currentTime / 1000000000}");

                foundTimestamp = !busMismatch;
            }
            
            
            Console.WriteLine($"Day 13b result: {currentTime}");
        }
    }
}