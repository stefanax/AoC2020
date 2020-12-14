using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class Day11
    {
        private InputFiles _inputFiles = new InputFiles();
        
        private enum SeatStatus
        {
            Floor,
            Free,
            Occupied
        }

        private void PrintGrid(List<List<SeatStatus>> grid)
        {
            Console.WriteLine("");
            foreach (var gridI in grid)
            {
                foreach (var gridJ in gridI)
                {
                    switch (gridJ)
                    {
                        case SeatStatus.Floor: Console.Write(".");
                            break;
                        case SeatStatus.Free: Console.Write("L");
                            break;
                        case SeatStatus.Occupied: Console.Write("#");
                            break;
                    }
                }
                Console.WriteLine("");
            }
        }

        public void Step1()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(11, false));
            var grids = new Tuple<List<List<SeatStatus>>, List<List<SeatStatus>>>(new List<List<SeatStatus>>(), new List<List<SeatStatus>>());

            // Populate top of "wall" area, including top of left-and-right "walls"
            grids.Item1.Add(new List<SeatStatus>());
            grids.Item2.Add(new List<SeatStatus>());
            for (var i = -1; i <= inputList[0].Length; i++)
            {
                grids.Item1[0].Add(SeatStatus.Floor);
                grids.Item2[0].Add(SeatStatus.Floor);
            }

            for (var i = 0; i < inputList.Length; i++)
            {
                grids.Item1.Add(new List<SeatStatus>());
                grids.Item2.Add(new List<SeatStatus>());
                grids.Item1[grids.Item1.Count-1].Add(SeatStatus.Floor);  // Add left "wall"
                grids.Item2[grids.Item2.Count-1].Add(SeatStatus.Floor);  // Add left "wall"

                foreach (var inputChar in inputList[i].ToCharArray())
                {
                    switch (inputChar)
                    {
                        case 'L': grids.Item1[grids.Item1.Count-1].Add(SeatStatus.Free);
                            grids.Item2[grids.Item2.Count-1].Add(SeatStatus.Free);
                            break;
                        case '.': grids.Item1[grids.Item1.Count-1].Add(SeatStatus.Floor);
                            grids.Item2[grids.Item2.Count-1].Add(SeatStatus.Floor);
                            break;
                        default: throw new Exception("Not a floor or seat...");
                    }
                }
                
                grids.Item1[grids.Item1.Count-1].Add(SeatStatus.Floor);  // Add right "wall"
                grids.Item2[grids.Item2.Count-1].Add(SeatStatus.Floor);  // Add right "wall"
            }
            
            // Populate bottom of "wall" area, including bottom of left-and-right "walls"
            grids.Item1.Add(new List<SeatStatus>());
            grids.Item2.Add(new List<SeatStatus>());
            for (var i = -1; i <= inputList[0].Length; i++)
            {
                grids.Item1[grids.Item1.Count-1].Add(SeatStatus.Floor);
                grids.Item2[grids.Item2.Count-1].Add(SeatStatus.Floor);
            }
            
            var sideToggle = false;
            var gridsAreEqual = false;

            do
            {
                List<List<SeatStatus>> sourceGrid;
                List<List<SeatStatus>> targetGrid;

                if (sideToggle)
                {
                    sourceGrid = grids.Item1;
                    targetGrid = grids.Item2;
                }
                else
                {
                    sourceGrid = grids.Item2;
                    targetGrid = grids.Item1;
                }

                sideToggle = !sideToggle;
                
                //PrintGrid(sourceGrid);

                // Go through the chairs in one side of the Tuple, and set it in the other...
                for (var i = 1; i < sourceGrid.Count - 1; i++)
                {
                    for (var j = 1; j < sourceGrid[0].Count - 1; j++)
                    {
                        if (sourceGrid[i][j] == SeatStatus.Floor) continue;
                        var occupiedAround = 0;
                        if (sourceGrid[i - 1][j - 1] == SeatStatus.Occupied) occupiedAround++;
                        if (sourceGrid[i - 1][j] == SeatStatus.Occupied) occupiedAround++;
                        if (sourceGrid[i - 1][j + 1] == SeatStatus.Occupied) occupiedAround++;
                        if (sourceGrid[i][j - 1] == SeatStatus.Occupied) occupiedAround++;
                        if (sourceGrid[i][j + 1] == SeatStatus.Occupied) occupiedAround++;
                        if (sourceGrid[i + 1][j - 1] == SeatStatus.Occupied) occupiedAround++;
                        if (sourceGrid[i + 1][j] == SeatStatus.Occupied) occupiedAround++;
                        if (sourceGrid[i + 1][j + 1] == SeatStatus.Occupied) occupiedAround++;

                        if (occupiedAround == 0)
                        {
                            targetGrid[i][j] = SeatStatus.Occupied;
                        }
                        else if (occupiedAround >= 4)
                        {
                            targetGrid[i][j] = SeatStatus.Free;
                        }
                        else
                        {
                            targetGrid[i][j] = sourceGrid[i][j];
                        }
                    }
                }
                
                // Compare the grids
                var diffFound = false;
                for (var i = 1; i < sourceGrid.Count - 1; i++)
                {
                    for (var j = 1; j < sourceGrid[0].Count - 1; j++)
                    {
                        if (sourceGrid[i][j] != targetGrid[i][j])
                        {
                            diffFound = true;
                            i = 10000;
                            j = 10000;
                        }
                    }
                }

                gridsAreEqual = !diffFound;

            } while(!gridsAreEqual);
            
            
            // Count the seats
            var occupiedSeatCount = 0;
            for (var i = 1; i < grids.Item1.Count - 1; i++)
            {
                for (var j = 1; j < grids.Item1.Count - 1; j++)
                {
                    if (grids.Item1[i][j] == SeatStatus.Occupied)
                    {
                        occupiedSeatCount++;
                    }
                }
            }
            
            Console.WriteLine($"Day 11a result: {occupiedSeatCount}");
        }

        public void Step2()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(11, false));
            var grids = new Tuple<List<List<SeatStatus>>, List<List<SeatStatus>>>(new List<List<SeatStatus>>(), new List<List<SeatStatus>>());

            // Populate top of "wall" area, including top of left-and-right "walls"
            grids.Item1.Add(new List<SeatStatus>());
            grids.Item2.Add(new List<SeatStatus>());
            for (var i = -1; i <= inputList[0].Length; i++)
            {
                grids.Item1[0].Add(SeatStatus.Floor);
                grids.Item2[0].Add(SeatStatus.Floor);
            }

            for (var i = 0; i < inputList.Length; i++)
            {
                grids.Item1.Add(new List<SeatStatus>());
                grids.Item2.Add(new List<SeatStatus>());
                grids.Item1[grids.Item1.Count-1].Add(SeatStatus.Floor);  // Add left "wall"
                grids.Item2[grids.Item2.Count-1].Add(SeatStatus.Floor);  // Add left "wall"

                foreach (var inputChar in inputList[i].ToCharArray())
                {
                    switch (inputChar)
                    {
                        case 'L': grids.Item1[grids.Item1.Count-1].Add(SeatStatus.Free);
                            grids.Item2[grids.Item2.Count-1].Add(SeatStatus.Free);
                            break;
                        case '.': grids.Item1[grids.Item1.Count-1].Add(SeatStatus.Floor);
                            grids.Item2[grids.Item2.Count-1].Add(SeatStatus.Floor);
                            break;
                        default: throw new Exception("Not a floor or seat...");
                    }
                }
                
                grids.Item1[grids.Item1.Count-1].Add(SeatStatus.Floor);  // Add right "wall"
                grids.Item2[grids.Item2.Count-1].Add(SeatStatus.Floor);  // Add right "wall"
            }
            
            // Populate bottom of "wall" area, including bottom of left-and-right "walls"
            grids.Item1.Add(new List<SeatStatus>());
            grids.Item2.Add(new List<SeatStatus>());
            for (var i = -1; i <= inputList[0].Length; i++)
            {
                grids.Item1[grids.Item1.Count-1].Add(SeatStatus.Floor);
                grids.Item2[grids.Item2.Count-1].Add(SeatStatus.Floor);
            }
            
            var sideToggle = false;
            var gridsAreEqual = false;

            do
            {
                List<List<SeatStatus>> sourceGrid;
                List<List<SeatStatus>> targetGrid;

                if (sideToggle)
                {
                    sourceGrid = grids.Item1;
                    targetGrid = grids.Item2;
                }
                else
                {
                    sourceGrid = grids.Item2;
                    targetGrid = grids.Item1;
                }

                sideToggle = !sideToggle;
                
                //PrintGrid(sourceGrid);

                // Go through the chairs in one side of the Tuple, and set it in the other...
                for (var i = 1; i < sourceGrid.Count - 1; i++)
                {
                    for (var j = 1; j < sourceGrid[0].Count - 1; j++)
                    {
                        if (sourceGrid[i][j] == SeatStatus.Floor) continue;
                        var occupiedAround = 0;

                        for (var x = 1; x < 1000; x++)
                        {
                            if (i - x < 0 || j - x < 0)
                            {
                                break;
                            }

                            if (sourceGrid[i - x][j - x] == SeatStatus.Occupied)
                            {
                                occupiedAround++;
                                break;
                            }
                            
                            if (sourceGrid[i - x][j - x] == SeatStatus.Free) break;
                        }

                        for (var x = 1; x < 1000; x++)
                        {
                            if (i - x < 0)
                            {
                                break;
                            }

                            if (sourceGrid[i - x][j] == SeatStatus.Occupied)
                            {
                                occupiedAround++;
                                break;
                            }
                            
                            if (sourceGrid[i - x][j] == SeatStatus.Free) break;
                        }

                        for (var x = 1; x < 1000; x++)
                        {
                            if (i - x < 0 || j + x >= sourceGrid[0].Count)
                            {
                                break;
                            }

                            if (sourceGrid[i - x][j + x] == SeatStatus.Occupied)
                            {
                                occupiedAround++;
                                break;
                            }
                            
                            if (sourceGrid[i - x][j + x] == SeatStatus.Free) break;
                        }

                        for (var x = 1; x < 1000; x++)
                        {
                            if (j - x < 0)
                            {
                                break;
                            }

                            if (sourceGrid[i][j - x] == SeatStatus.Occupied)
                            {
                                occupiedAround++;
                                break;
                            }
                            
                            if (sourceGrid[i][j - x] == SeatStatus.Free) break;
                        }

                        for (var x = 1; x < 1000; x++)
                        {
                            if (j + x >= sourceGrid[0].Count)
                            {
                                break;
                            }

                            if (sourceGrid[i][j + x] == SeatStatus.Occupied)
                            {
                                occupiedAround++;
                                break;
                            }
                            
                            if (sourceGrid[i][j + x] == SeatStatus.Free) break;
                        }

                        for (var x = 1; x < 1000; x++)
                        {
                            if (i + x >= sourceGrid.Count || j - x < 0)
                            {
                                break;
                            }

                            if (sourceGrid[i + x][j - x] == SeatStatus.Occupied)
                            {
                                occupiedAround++;
                                break;
                            }
                            
                            if (sourceGrid[i + x][j - x] == SeatStatus.Free) break;
                        }

                        for (var x = 1; x < 1000; x++)
                        {
                            if (i + x >= sourceGrid.Count)
                            {
                                break;
                            }

                            if (sourceGrid[i + x][j] == SeatStatus.Occupied)
                            {
                                occupiedAround++;
                                break;
                            }
                            
                            if (sourceGrid[i + x][j] == SeatStatus.Free) break;
                        }

                        for (var x = 1; x < 1000; x++)
                        {
                            if (i + x >= sourceGrid.Count || j + x >= sourceGrid[0].Count)
                            {
                                break;
                            }

                            if (sourceGrid[i + x][j + x] == SeatStatus.Occupied)
                            {
                                occupiedAround++;
                                break;
                            }
                            
                            if (sourceGrid[i + x][j + x] == SeatStatus.Free) break;
                        }
                        
                        
                        if (occupiedAround == 0)
                        {
                            targetGrid[i][j] = SeatStatus.Occupied;
                        }
                        else if (occupiedAround >= 5)
                        {
                            targetGrid[i][j] = SeatStatus.Free;
                        }
                        else
                        {
                            targetGrid[i][j] = sourceGrid[i][j];
                        }
                    }
                }
                
                // Compare the grids
                var diffFound = false;
                for (var i = 1; i < sourceGrid.Count - 1; i++)
                {
                    for (var j = 1; j < sourceGrid[0].Count - 1; j++)
                    {
                        if (sourceGrid[i][j] != targetGrid[i][j])
                        {
                            diffFound = true;
                            i = 10000;
                            j = 10000;
                        }
                    }
                }

                gridsAreEqual = !diffFound;

            } while(!gridsAreEqual);
            
            
            // Count the seats
            var occupiedSeatCount = 0;
            for (var i = 1; i < grids.Item1.Count - 1; i++)
            {
                for (var j = 1; j < grids.Item1.Count - 1; j++)
                {
                    if (grids.Item1[i][j] == SeatStatus.Occupied)
                    {
                        occupiedSeatCount++;
                    }
                }
            }
            
            Console.WriteLine($"Day 11a result: {occupiedSeatCount}");
        }

    }
}