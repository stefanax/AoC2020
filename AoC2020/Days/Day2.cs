using System;

namespace AoC2020
{
    public class Day2
    {
        private InputFiles _inputFiles = new InputFiles();

        public void Step1()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(2, false));

            var validPasswords = 0;

            foreach (var input in inputList)
            {
                var data = input.Split(" ");
                var minAmount = Int32.Parse(data[0].Split("-")[0]);
                var maxAmount = Int32.Parse(data[0].Split("-")[1]);
                var letter = data[1].Substring(0, 1);
                var password = data[2];

                var lettersFound = 0;
                for (var i = 0; i < password.Length; i++)
                {
                    if (password.Substring(i, 1) == letter) lettersFound++;
                }

                if (lettersFound >= minAmount && lettersFound <= maxAmount) validPasswords++;
            }
            
            Console.WriteLine($"Day 2a result: {validPasswords}");
        }

        public void Step2()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(2, false));

            var validPasswords = 0;

            foreach (var input in inputList)
            {
                var data = input.Split(" ");
                var posFirst = Int32.Parse(data[0].Split("-")[0]);
                var posSecond = Int32.Parse(data[0].Split("-")[1]);
                var letter = data[1].Substring(0, 1);
                var password = data[2];

                var lettersFound = 0;
                if (password.Substring(posFirst - 1, 1) == letter) lettersFound++;
                if (password.Substring(posSecond - 1, 1) == letter) lettersFound++;

                if (lettersFound == 1) validPasswords++;
            }
            
            Console.WriteLine($"Day 2b result: {validPasswords}");
            
        }
    }
}