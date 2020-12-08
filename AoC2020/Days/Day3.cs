using System;

namespace AoC2020
{
    public class Day3
    {
        private InputFiles _inputFiles = new InputFiles();
        
        public void Step1()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(3, false));
            var inputWidth = inputList[0].Length;
            
            bool[][] grid = new bool[inputList.Length][];
            for (int i = 0; i < grid.Length; i++)
            {
                grid[i] = new bool[inputWidth];
                for (int j = 0; j < inputWidth; j++)
                {
                    grid[i][j] = inputList[i].Substring(j, 1) == "#" ? true : false;
                }
            }

            var column = 0;
            var treesHit = 0;
            
            for (int row = 0; row < grid.Length; row++)
            {
                if (grid[row][column])
                {
                    treesHit++;
                }

                column = (column + 3) % inputWidth;
            }
            
            Console.WriteLine($"Day 3a result: {treesHit} trees hit.");
        }

        public void Step2()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(3, false));
            var inputWidth = inputList[0].Length;
            
            bool[][] grid = new bool[inputList.Length][];
            for (int i = 0; i < grid.Length; i++)
            {
                grid[i] = new bool[inputWidth];
                for (int j = 0; j < inputWidth; j++)
                {
                    grid[i][j] = inputList[i].Substring(j, 1) == "#" ? true : false;
                }
            }

            var paths = new int[][]
            {
                new int[] {1, 1},
                new int[] {1, 3},
                new int[] {1, 5},
                new int[] {1, 7},
                new int[] {2, 1}
            };
            
            var result = 1L;

            foreach (var path in paths)
            {
                var column = 0;
                var treesHit = 0L;
                for (int row = 0; row < grid.Length; row += path[0])
                {
                    if (grid[row][column])
                    {
                        treesHit++;
                    }

                    column = (column + path[1]) % inputWidth;
                }

                result *= treesHit;
            }

            Console.WriteLine($"Day 3b result: {result}");
        }
    }
}