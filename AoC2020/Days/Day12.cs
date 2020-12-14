using System;
using System.Runtime.CompilerServices;

namespace AoC2020
{
    public class Day12
    {
        private InputFiles _inputFiles = new InputFiles();

        private class Boat
        {
            public int PosX = 0; // West-East
            public int PosY = 0; // North-South
            public string Direction = "E";

            public void Move(string instruction)
            {
                var action = instruction.Substring(0, 1);
                var value = Int32.Parse(instruction.Substring(1));

                switch (action)
                {
                    case "N": PosY += value;
                        break;
                    case "S": PosY -= value;
                        break;
                    case "E": PosX += value;
                        break;
                    case "W": PosX -= value;
                        break;
                    case "R":
                        while (value > 0)
                        {
                            switch (Direction)
                            {
                                case "N": Direction = "E";
                                    break;
                                case "E": Direction = "S";
                                    break;
                                case "S": Direction = "W";
                                    break;
                                case "W": Direction = "N";
                                    break;
                            }

                            value -= 90;
                        }
                        break;
                    case "L": 
                        while (value > 0)
                        {
                            switch (Direction)
                            {
                                case "N": Direction = "W";
                                    break;
                                case "E": Direction = "N";
                                    break;
                                case "S": Direction = "E";
                                    break;
                                case "W": Direction = "S";
                                    break;
                            }

                            value -= 90;
                        }
                        break;
                    case "F":
                        switch (Direction)
                        {
                            case "N": PosY += value;
                                break;
                            case "S": PosY -= value;
                                break;
                            case "E": PosX += value;
                                break;
                            case "W": PosX -= value;
                                break;
                        }
                        break;
                }
            }
        }

        private class BoatMk2
        {
            public int PosX = 0; // West-East
            public int PosY = 0; // North-South
            public int WaypointPosX = 10;
            public int WaypointPosY = 1;

            public void Move(string instruction)
            {
                var action = instruction.Substring(0, 1);
                var value = Int32.Parse(instruction.Substring(1));

                switch (action)
                {
                    case "N": WaypointPosY += value;
                        break;
                    case "S": WaypointPosY -= value;
                        break;
                    case "E": WaypointPosX += value;
                        break;
                    case "W": WaypointPosX -= value;
                        break;
                    case "R":
                        while (value > 0)
                        {
                            var temp = WaypointPosY;
                            WaypointPosY = 0 - WaypointPosX;
                            WaypointPosX = temp;

                            value -= 90;
                        }
                        break;
                    case "L": 
                        while (value > 0)
                        {
                            var temp = WaypointPosY;
                            WaypointPosY = WaypointPosX;
                            WaypointPosX = 0 - temp;

                            value -= 90;
                        }
                        break;
                    case "F":
                        while (value > 0)
                        {
                            PosX += WaypointPosX;
                            PosY += WaypointPosY;
                            value--;
                        }

                        break;
                }
            }
        }

        public void Step1()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(12, false));
            
            var boatyMcBoatface = new Boat();

            foreach (var command in inputList)
            {
                boatyMcBoatface.Move(command);
            }

            var distance = Math.Abs(boatyMcBoatface.PosX) + Math.Abs(boatyMcBoatface.PosY);
            Console.WriteLine($"Day 12a result: {distance}");
        }


        public void Step2()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(12, false));
            
            var boatyMcBoatface = new BoatMk2();

            foreach (var command in inputList)
            {
                boatyMcBoatface.Move(command);
            }

            var distance = Math.Abs(boatyMcBoatface.PosX) + Math.Abs(boatyMcBoatface.PosY);
            Console.WriteLine($"Day 12b result: {distance}");
        }
    }
}