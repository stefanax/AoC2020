using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class Day5
    {
        private InputFiles _inputFiles = new InputFiles();

        public void Step1()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(5, false));

            var highestSeatId = 0;

            foreach (var seatCode in inputList)
            {
                var rowNumber = 0;
                var columnNumber = 0;

                if (seatCode.Substring(0, 1) == "B") rowNumber += 64;
                if (seatCode.Substring(1, 1) == "B") rowNumber += 32;
                if (seatCode.Substring(2, 1) == "B") rowNumber += 16;
                if (seatCode.Substring(3, 1) == "B") rowNumber += 8;
                if (seatCode.Substring(4, 1) == "B") rowNumber += 4;
                if (seatCode.Substring(5, 1) == "B") rowNumber += 2;
                if (seatCode.Substring(6, 1) == "B") rowNumber += 1;
                
                if (seatCode.Substring(7, 1) == "R") columnNumber += 4;
                if (seatCode.Substring(8, 1) == "R") columnNumber += 2;
                if (seatCode.Substring(9, 1) == "R") columnNumber += 1;

                var currentSeatId = rowNumber * 8 + columnNumber;
                if (currentSeatId > highestSeatId) highestSeatId = currentSeatId;
            }
            
            
            Console.WriteLine($"Day 5a result: {highestSeatId} is the highest seat ID.");
        }


        public void Step2()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(5, false));
            
            List<int> knownSeats = new List<int>();
            
            foreach (var seatCode in inputList)
            {
                var rowNumber = 0;
                var columnNumber = 0;

                if (seatCode.Substring(0, 1) == "B") rowNumber += 64;
                if (seatCode.Substring(1, 1) == "B") rowNumber += 32;
                if (seatCode.Substring(2, 1) == "B") rowNumber += 16;
                if (seatCode.Substring(3, 1) == "B") rowNumber += 8;
                if (seatCode.Substring(4, 1) == "B") rowNumber += 4;
                if (seatCode.Substring(5, 1) == "B") rowNumber += 2;
                if (seatCode.Substring(6, 1) == "B") rowNumber += 1;
                
                if (seatCode.Substring(7, 1) == "R") columnNumber += 4;
                if (seatCode.Substring(8, 1) == "R") columnNumber += 2;
                if (seatCode.Substring(9, 1) == "R") columnNumber += 1;

                var currentSeatId = rowNumber * 8 + columnNumber;
                knownSeats.Add(currentSeatId);
            }
            
            
            // Horrible way of doing this, but should work...
            for (var mySeat = 0; mySeat <= 5595; mySeat++)
            {
                var foundExact = false;
                var foundMinusOne = false;
                var foundPlusOne = false;

                foreach (var testSeat in knownSeats)
                {
                    if (testSeat == mySeat) foundExact = true;
                    if (testSeat == mySeat - 1) foundMinusOne = true;
                    if (testSeat == mySeat + 1) foundPlusOne = true;
                }

                if (foundMinusOne && foundPlusOne && !foundExact)
                {
                    Console.WriteLine($"Day 5b result: {mySeat} is my seat");
                }
            }
        }
    }
}