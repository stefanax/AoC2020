using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AoC2020
{
    public class Day4
    {
        private class Passport
        {
            public string BirthYear { get; set; }
            public string IssueYear { get; set; }
            public string ExpirationYear { get; set; }
            public string Height { get; set; }
            public string HairColour { get; set; }
            public string EyeColour { get; set; }
            public string PassportID { get; set; }
            public string CountryID { get; set; }

            public bool isValid(bool ignoreCountryID = false)
            {
                var result = (string.IsNullOrEmpty(BirthYear) || 
                              string.IsNullOrEmpty(IssueYear) || 
                              string.IsNullOrEmpty(ExpirationYear) || 
                              string.IsNullOrEmpty(Height) || 
                              string.IsNullOrEmpty(HairColour) || 
                              string.IsNullOrEmpty(EyeColour) || 
                              string.IsNullOrEmpty(PassportID) || 
                              (string.IsNullOrEmpty(CountryID) && !ignoreCountryID));
                return !result;
            }
        }

        private class BetterPassport : Passport
        {
            public bool isValid(bool ignoreCountryID = false)
            {
                try
                {
                    if (string.IsNullOrEmpty(BirthYear) || Int32.Parse(BirthYear) < 1920 || Int32.Parse(BirthYear) > 2002) return false;
                    if (string.IsNullOrEmpty(IssueYear) || Int32.Parse(IssueYear) < 2010 || Int32.Parse(IssueYear) > 2020) return false;
                    if (string.IsNullOrEmpty(ExpirationYear) || Int32.Parse(ExpirationYear) < 2020 || Int32.Parse(ExpirationYear) > 2030) return false;
                    if (string.IsNullOrEmpty(Height)) return false;
                    
                    if (Height.Length < 3 || (Height.Substring(Height.Length - 2) != "cm" && Height.Substring(Height.Length - 2) != "in")) return false;
                    if (Height.Substring(Height.Length - 2) == "cm")
                    {
                        if (Int32.Parse(Height.Substring(0, Height.Length - 2)) < 150 || Int32.Parse(Height.Substring(0, Height.Length - 2)) > 193) return false;
                    }
                    else
                    {
                        if (Int32.Parse(Height.Substring(0, Height.Length - 2)) < 59 || Int32.Parse(Height.Substring(0, Height.Length - 2)) > 76) return false;
                    }

                    if (string.IsNullOrEmpty(HairColour)) return false;
                    var colourPattern = @"^\#[0-9a-f]{6}$";
                    var regex = new Regex(colourPattern);
                    if (!regex.IsMatch(HairColour)) return false;

                    if (string.IsNullOrEmpty(EyeColour) ||
                        (EyeColour != "amb" &&
                         EyeColour != "blu" &&
                         EyeColour != "brn" &&
                         EyeColour != "gry" &&
                         EyeColour != "grn" &&
                         EyeColour != "hzl" &&
                         EyeColour != "oth"
                        )) return false;
                    
                    var passportIDPattern = @"^[0-9]{9}$";
                    regex = new Regex(passportIDPattern);
                    if (string.IsNullOrEmpty(PassportID) || !regex.IsMatch(PassportID)) return false;
                    
                }
                catch (Exception e)
                {
                    return false;
                }

                return true;
            }
        }
        
        private InputFiles _inputFiles = new InputFiles();

        public void Step1()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(4, false));

            var passports = new List<Passport>();

            Passport passport = null;
            
            foreach (var inputLine in inputList)
            {
                if (string.IsNullOrEmpty(inputLine))
                {
                    passports.Add(passport);
                    passport = null;
                    continue;
                }
                if (passport is null) { passport = new Passport(); }

                foreach (var inputBlock in inputLine.Split(" "))
                {
                    var inputBlockSplit = inputBlock.Split(":");
                    switch (inputBlockSplit[0])
                    {
                        case "byr": passport.BirthYear = inputBlockSplit[1];
                            break;
                        case "iyr": passport.IssueYear = inputBlockSplit[1];
                            break;
                        case "eyr": passport.ExpirationYear = inputBlockSplit[1];
                            break;
                        case "hgt": passport.Height = inputBlockSplit[1];
                            break;
                        case "hcl": passport.HairColour = inputBlockSplit[1];
                            break;
                        case "ecl": passport.EyeColour = inputBlockSplit[1];
                            break;
                        case "pid": passport.PassportID = inputBlockSplit[1];
                            break;
                        case "cid": passport.CountryID = inputBlockSplit[1];
                            break;
                    }
                }
            }
            passports.Add(passport); //End Of File...

            var validPassportCount = 0;
            foreach (var passportToValidate in passports)
            {
                if (passportToValidate.isValid(true)) validPassportCount++;
            }

            Console.WriteLine($"Day 4a result: {validPassportCount} passports valid.");
        }


        public void Step2()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(4, false));

            var passports = new List<BetterPassport>();

            BetterPassport passport = null;
            
            foreach (var inputLine in inputList)
            {
                if (string.IsNullOrEmpty(inputLine))
                {
                    passports.Add(passport);
                    passport = null;
                    continue;
                }
                if (passport is null) { passport = new BetterPassport(); }

                foreach (var inputBlock in inputLine.Split(" "))
                {
                    var inputBlockSplit = inputBlock.Split(":");
                    switch (inputBlockSplit[0])
                    {
                        case "byr": passport.BirthYear = inputBlockSplit[1];
                            break;
                        case "iyr": passport.IssueYear = inputBlockSplit[1];
                            break;
                        case "eyr": passport.ExpirationYear = inputBlockSplit[1];
                            break;
                        case "hgt": passport.Height = inputBlockSplit[1];
                            break;
                        case "hcl": passport.HairColour = inputBlockSplit[1];
                            break;
                        case "ecl": passport.EyeColour = inputBlockSplit[1];
                            break;
                        case "pid": passport.PassportID = inputBlockSplit[1];
                            break;
                        case "cid": passport.CountryID = inputBlockSplit[1];
                            break;
                    }
                }
            }
            passports.Add(passport); //End Of File...

            var validPassportCount = 0;
            foreach (var passportToValidate in passports)
            {
                if (passportToValidate.isValid(true)) validPassportCount++;
            }

            Console.WriteLine($"Day 4b result: {validPassportCount} passports valid.");
        }
        
    }
}