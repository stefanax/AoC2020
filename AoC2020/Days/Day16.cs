using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class Day16
    {
        private InputFiles _inputFiles = new InputFiles();
        
        
        // departure location: 31-201 or 227-951
        private bool MatchDepartureLocation(int valueToTest)
        {
            if (valueToTest >= 31 && valueToTest <= 201) return true;
            if (valueToTest >= 227 && valueToTest <= 951) return true;
            return false;
        }
        
        // departure station: 49-885 or 892-961
        private bool MatchDepartureStation(int valueToTest)
        {
            if (valueToTest >= 49 && valueToTest <= 885) return true;
            if (valueToTest >= 892 && valueToTest <= 961) return true;
            return false;
        }

        // departure platform: 36-248 or 258-974
        private bool MatchDeparturePlatform(int valueToTest)
        {
            if (valueToTest >= 36 && valueToTest <= 248) return true;
            if (valueToTest >= 258 && valueToTest <= 974) return true;
            return false;
        }

        // departure track: 37-507 or 527-965
        private bool MatchDepartureTrack(int valueToTest)
        {
            if (valueToTest >= 37 && valueToTest <= 507) return true;
            if (valueToTest >= 527 && valueToTest <= 965) return true;
            return false;
        }

        // departure date: 37-331 or 351-970
        private bool MatchDepartureDate(int valueToTest)
        {
            if (valueToTest >= 37 && valueToTest <= 331) return true;
            if (valueToTest >= 351 && valueToTest <= 970) return true;
            return false;
        }

        // departure time: 38-370 or 382-970
        private bool MatchDepartureTime(int valueToTest)
        {
            if (valueToTest >= 38 && valueToTest <= 370) return true;
            if (valueToTest >= 382 && valueToTest <= 970) return true;
            return false;
        }

        // arrival location: 33-686 or 711-960
        private bool MatchArrivalLocation(int valueToTest)
        {
            if (valueToTest >= 33 && valueToTest <= 686) return true;
            if (valueToTest >= 711 && valueToTest <= 960) return true;
            return false;
        }

        // arrival station: 46-753 or 775-953
        private bool MatchArrivalStation(int valueToTest)
        {
            if (valueToTest >= 46 && valueToTest <= 753) return true;
            if (valueToTest >= 775 && valueToTest <= 953) return true;
            return false;
        }

        // arrival platform: 34-138 or 154-959
        private bool MatchArrivalPlatform(int valueToTest)
        {
            if (valueToTest >= 34 && valueToTest <= 138) return true;
            if (valueToTest >= 154 && valueToTest <= 959) return true;
            return false;
        }

        // arrival track: 26-167 or 181-961
        private bool MatchArrivalTrack(int valueToTest)
        {
            if (valueToTest >= 26 && valueToTest <= 167) return true;
            if (valueToTest >= 181 && valueToTest <= 961) return true;
            return false;
        }

        // class: 43-664 or 675-968
        private bool MatchClass(int valueToTest)
        {
            if (valueToTest >= 43 && valueToTest <= 664) return true;
            if (valueToTest >= 675 && valueToTest <= 968) return true;
            return false;
        }

        // duration: 47-603 or 620-954
        private bool MatchDuration(int valueToTest)
        {
            if (valueToTest >= 47 && valueToTest <= 603) return true;
            if (valueToTest >= 620 && valueToTest <= 954) return true;
            return false;
        }

        // price: 40-290 or 313-972
        private bool MatchPrice(int valueToTest)
        {
            if (valueToTest >= 40 && valueToTest <= 290) return true;
            if (valueToTest >= 313 && valueToTest <= 972) return true;
            return false;
        }

        // route: 37-792 or 799-972
        private bool MatchRoute(int valueToTest)
        {
            if (valueToTest >= 37 && valueToTest <= 792) return true;
            if (valueToTest >= 799 && valueToTest <= 972) return true;
            return false;
        }

        // row: 32-97 or 115-954
        private bool MatchRow(int valueToTest)
        {
            if (valueToTest >= 32 && valueToTest <= 97) return true;
            if (valueToTest >= 115 && valueToTest <= 954) return true;
            return false;
        }

        // seat: 25-916 or 942-966
        private bool MatchSeat(int valueToTest)
        {
            if (valueToTest >= 25 && valueToTest <= 916) return true;
            if (valueToTest >= 942 && valueToTest <= 966) return true;
            return false;
        }

        // train: 39-572 or 587-966
        private bool MatchTrain(int valueToTest)
        {
            if (valueToTest >= 39 && valueToTest <= 572) return true;
            if (valueToTest >= 587 && valueToTest <= 966) return true;
            return false;
        }

        // type: 25-834 or 858-953
        private bool MatchType(int valueToTest)
        {
            if (valueToTest >= 25 && valueToTest <= 834) return true;
            if (valueToTest >= 858 && valueToTest <= 953) return true;
            return false;
        }

        // wagon: 48-534 or 544-959
        private bool MatchWagon(int valueToTest)
        {
            if (valueToTest >= 48 && valueToTest <= 534) return true;
            if (valueToTest >= 544 && valueToTest <= 959) return true;
            return false;
        }

        // zone: 47-442 or 463-969
        private bool MatchZone(int valueToTest)
        {
            if (valueToTest >= 47 && valueToTest <= 442) return true;
            if (valueToTest >= 463 && valueToTest <= 969) return true;
            return false;
        }

        private bool MatchError(int valueToTest)
        {
            if (MatchDepartureLocation(valueToTest)) return false;
            if (MatchDepartureStation(valueToTest)) return false;
            if (MatchDeparturePlatform(valueToTest)) return false;
            if (MatchDepartureTrack(valueToTest)) return false;
            if (MatchDepartureDate(valueToTest)) return false;
            if (MatchDepartureTime(valueToTest)) return false;
            if (MatchArrivalLocation(valueToTest)) return false;
            if (MatchArrivalStation(valueToTest)) return false;
            if (MatchArrivalPlatform(valueToTest)) return false;
            if (MatchArrivalTrack(valueToTest)) return false;
            if (MatchClass(valueToTest)) return false;
            if (MatchDuration(valueToTest)) return false;
            if (MatchPrice(valueToTest)) return false;
            if (MatchRoute(valueToTest)) return false;
            if (MatchRow(valueToTest)) return false;
            if (MatchSeat(valueToTest)) return false;
            if (MatchTrain(valueToTest)) return false;
            if (MatchType(valueToTest)) return false;
            if (MatchWagon(valueToTest)) return false;
            if (MatchZone(valueToTest)) return false;

            return true;
        }


        public void Step1()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(16, false));

            var totalErrorRate = 0;
            foreach (var ticket in inputList)
            {
                foreach (var ticketItem in ticket.Split(","))
                {
                    var ticketItemInt = Int32.Parse(ticketItem);
                    if (MatchError(ticketItemInt)) totalErrorRate += ticketItemInt;
                }
            }
            
            Console.WriteLine($"Day 16a result: {totalErrorRate}");
        }


        private void InsertMismatch(int ticketItemPos, string dataName, Dictionary<int, List<string>> data)
        {
            if (!data.ContainsKey(ticketItemPos)) data.Add(ticketItemPos, new List<string>());
            if (!data[ticketItemPos].Contains(dataName)) data[ticketItemPos].Add(dataName);
        }

        public void Step2()
        {
            var inputList = _inputFiles.SplitString(_inputFiles.ReadInputFileForDay(16, false));

            var cleanedInputList = new List<string>();

            foreach (var ticket in inputList)
            {
                var foundErrors = false;
                foreach (var ticketItem in ticket.Split(","))
                {
                    var ticketItemInt = Int32.Parse(ticketItem);
                    if (MatchError(ticketItemInt))
                    {
                        foundErrors = true;
                        break;
                    }
                }
                if (!foundErrors) cleanedInputList.Add(ticket);
            }

            var fieldMismatches = new Dictionary<int, List<string>>();

            foreach (var ticket in cleanedInputList)
            {
                var ticketItems = ticket.Split(",");
                for (var i = 0; i < ticketItems.Length; i++)
                {
                    var ticketItemToTest = Int32.Parse(ticketItems[i]);
                    if (!MatchDepartureLocation(ticketItemToTest))
                    {
                        InsertMismatch(i, "Departure Location", fieldMismatches);
                    }
                    if (!MatchDepartureStation(ticketItemToTest))
                    {
                        InsertMismatch(i, "Departure Station", fieldMismatches);
                    }
                    if (!MatchDeparturePlatform(ticketItemToTest))
                    {
                        InsertMismatch(i, "Departure Platform", fieldMismatches);
                    }
                    if (!MatchDepartureTrack(ticketItemToTest))
                    {
                        InsertMismatch(i, "Departure Track", fieldMismatches);
                    }
                    if (!MatchDepartureDate(ticketItemToTest))
                    {
                        InsertMismatch(i, "Departure Date", fieldMismatches);
                    }
                    if (!MatchDepartureTime(ticketItemToTest))
                    {
                        InsertMismatch(i, "Departure Time", fieldMismatches);
                    }
                    if (!MatchArrivalLocation(ticketItemToTest))
                    {
                        InsertMismatch(i, "Arrival Location", fieldMismatches);
                    }
                    if (!MatchArrivalStation(ticketItemToTest))
                    {
                        InsertMismatch(i, "Arrival Station", fieldMismatches);
                    }
                    if (!MatchArrivalPlatform(ticketItemToTest))
                    {
                        InsertMismatch(i, "Arrival Platform", fieldMismatches);
                    }
                    if (!MatchArrivalTrack(ticketItemToTest))
                    {
                        InsertMismatch(i, "Arrival Track", fieldMismatches);
                    }
                    if (!MatchClass(ticketItemToTest))
                    {
                        InsertMismatch(i, "Class", fieldMismatches);
                    }
                    if (!MatchDuration(ticketItemToTest))
                    {
                        InsertMismatch(i, "Duration", fieldMismatches);
                    }
                    if (!MatchPrice(ticketItemToTest))
                    {
                        InsertMismatch(i, "Price", fieldMismatches);
                    }
                    if (!MatchRoute(ticketItemToTest))
                    {
                        InsertMismatch(i, "Route", fieldMismatches);
                    }
                    if (!MatchRow(ticketItemToTest))
                    {
                        InsertMismatch(i, "Row", fieldMismatches);
                    }
                    if (!MatchSeat(ticketItemToTest))
                    {
                        InsertMismatch(i, "Seat", fieldMismatches);
                    }
                    if (!MatchTrain(ticketItemToTest))
                    {
                        InsertMismatch(i, "Train", fieldMismatches);
                    }
                    if (!MatchType(ticketItemToTest))
                    {
                        InsertMismatch(i, "Type", fieldMismatches);
                    }
                    if (!MatchWagon(ticketItemToTest))
                    {
                        InsertMismatch(i, "Wagon", fieldMismatches);
                    }
                    if (!MatchZone(ticketItemToTest))
                    {
                        InsertMismatch(i, "Zone", fieldMismatches);
                    }
                }
                
            }

            Console.WriteLine("Positions:          00 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19");
            Console.Write("Departure Location: ");
            for (var i = 0; i < 20; i++)
            {
                if (!fieldMismatches.ContainsKey(i) || !fieldMismatches[i].Contains("Departure Location"))
                {
                    Console.Write(" X ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine("");
            Console.Write("Departure Station:  ");
            for (var i = 0; i < 20; i++)
            {
                if (!fieldMismatches.ContainsKey(i) || !fieldMismatches[i].Contains("Departure Station"))
                {
                    Console.Write(" X ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine("");
            Console.Write("Departure Platform: ");
            for (var i = 0; i < 20; i++)
            {
                if (!fieldMismatches.ContainsKey(i) || !fieldMismatches[i].Contains("Departure Platform"))
                {
                    Console.Write(" X ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine("");
            Console.Write("Departure Track:    ");
            for (var i = 0; i < 20; i++)
            {
                if (!fieldMismatches.ContainsKey(i) || !fieldMismatches[i].Contains("Departure Track"))
                {
                    Console.Write(" X ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine("");
            Console.Write("Departure Date:      ");
            for (var i = 0; i < 20; i++)
            {
                if (!fieldMismatches.ContainsKey(i) || !fieldMismatches[i].Contains("Departure Date"))
                {
                    Console.Write(" X ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine("");
            Console.Write("Departure Time:      ");
            for (var i = 0; i < 20; i++)
            {
                if (!fieldMismatches.ContainsKey(i) || !fieldMismatches[i].Contains("Departure Time"))
                {
                    Console.Write(" X ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine("");
            Console.Write("Arrival Location:    ");
            for (var i = 0; i < 20; i++)
            {
                if (!fieldMismatches.ContainsKey(i) || !fieldMismatches[i].Contains("Arrival Location"))
                {
                    Console.Write(" X ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine("");
            Console.Write("Arrival Station:     ");
            for (var i = 0; i < 20; i++)
            {
                if (!fieldMismatches.ContainsKey(i) || !fieldMismatches[i].Contains("Arrival Station"))
                {
                    Console.Write(" X ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine("");
            Console.Write("Arrival Platform:    ");
            for (var i = 0; i < 20; i++)
            {
                if (!fieldMismatches.ContainsKey(i) || !fieldMismatches[i].Contains("Arrival platform"))
                {
                    Console.Write(" X ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine("");
            Console.Write("Arrival Track:       ");
            for (var i = 0; i < 20; i++)
            {
                if (!fieldMismatches.ContainsKey(i) || !fieldMismatches[i].Contains("Arrival Track"))
                {
                    Console.Write(" X ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine("");
            Console.Write("Class:               ");
            for (var i = 0; i < 20; i++)
            {
                if (!fieldMismatches.ContainsKey(i) || !fieldMismatches[i].Contains("Class"))
                {
                    Console.Write(" X ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine("");
            Console.Write("Duration:            ");
            for (var i = 0; i < 20; i++)
            {
                if (!fieldMismatches.ContainsKey(i) || !fieldMismatches[i].Contains("Duration"))
                {
                    Console.Write(" X ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine("");
            Console.Write("Price:               ");
            for (var i = 0; i < 20; i++)
            {
                if (!fieldMismatches.ContainsKey(i) || !fieldMismatches[i].Contains("Price"))
                {
                    Console.Write(" X ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine("");
            Console.Write("Route:               ");
            for (var i = 0; i < 20; i++)
            {
                if (!fieldMismatches.ContainsKey(i) || !fieldMismatches[i].Contains("Route"))
                {
                    Console.Write(" X ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine("");
            Console.Write("Row:                 ");
            for (var i = 0; i < 20; i++)
            {
                if (!fieldMismatches.ContainsKey(i) || !fieldMismatches[i].Contains("Row"))
                {
                    Console.Write(" X ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine("");
            Console.Write("Seat:                ");
            for (var i = 0; i < 20; i++)
            {
                if (!fieldMismatches.ContainsKey(i) || !fieldMismatches[i].Contains("Seat"))
                {
                    Console.Write(" X ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine("");
            Console.Write("Train:               ");
            for (var i = 0; i < 20; i++)
            {
                if (!fieldMismatches.ContainsKey(i) || !fieldMismatches[i].Contains("Train"))
                {
                    Console.Write(" X ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine("");
            Console.Write("Type:                ");
            for (var i = 0; i < 20; i++)
            {
                if (!fieldMismatches.ContainsKey(i) || !fieldMismatches[i].Contains("Type"))
                {
                    Console.Write(" X ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine("");
            Console.Write("Wagon:               ");
            for (var i = 0; i < 20; i++)
            {
                if (!fieldMismatches.ContainsKey(i) || !fieldMismatches[i].Contains("Wagon"))
                {
                    Console.Write(" X ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine("");
            Console.Write("Zone:                ");
            for (var i = 0; i < 20; i++)
            {
                if (!fieldMismatches.ContainsKey(i) || !fieldMismatches[i].Contains("Zone"))
                {
                    Console.Write(" X ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine("");

            var result = 0;
            
            Console.WriteLine($"Day 16b result: {result}");  //NOTE: Couldn't be arsed, did the last bit manually...
        }

    }
}