using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code.Classes
{
    public static class Day3
    {
        private static readonly string _filePath = "C:\\Users\\Adam\\Documents\\Sparta\\Advent of Code\\Advent_of_Code\\Advent_of_Code\\Text_Files\\Day3_Input.txt";
        
        private static char GetDuplicateItem(string input)
        {
            string compartmentOne = input.Substring(0, input.Length / 2);
            string compartmentTwo = input.Substring(input.Length / 2);

            foreach (var letterOne in compartmentOne)
            {
                foreach (var letterTwo in compartmentTwo)
                {
                    if (letterOne == letterTwo)
                    {
                        return letterOne;
                    }
                }
            }

            throw new ArgumentException("Input string does not contain a duplicate letter");
        }

        private static char GetBadge(string[] input)
        {
            if (input.Length != 3)
            {
                throw new ArgumentException("Input array length must be exactly 3");
            }

            foreach (var letterOne in input[0])
            {
                foreach (var letterTwo in input[1])
                {
                    if (letterOne == letterTwo)
                    {
                        foreach (var letterThree in input[2])
                        {
                            if (letterOne == letterThree)
                            {
                                return letterOne;
                            }
                        }
                    }
                }
            }

            throw new ArgumentException("Array of strings do not have a letter in common");
        }

        private static int GetPriorityValue(char input)
        {
            int value;

            if (Char.IsLower(input))
            {
                value = input - 96;
            }
            else
            {
                value = input - 38;
            }

            return value;
        }

        public static int GetPriorityValueForAllRucksacks()
        {
            int totalPriorityValue = 0;

            foreach (var line in File.ReadLines(_filePath))
            {
                totalPriorityValue += GetPriorityValue(GetDuplicateItem(line));
            }
            
            return totalPriorityValue;
        }

        public static int GetTotalPriorityValueForAllGroupBadges()
        {
            int totalPriorityValue = 0;

            int numOfLinesToArray = 0;
            var group = new List<string>();
            foreach (var line in File.ReadLines(_filePath))
            {
                group.Add(line);
                //numOfLinesToArray++;

                if (group.Count % 3 == 0)
                {
                    string[] array = group.ToArray();
                    totalPriorityValue += GetPriorityValue(GetBadge(array));
                    group.Clear();
                    numOfLinesToArray = 0;
                }
            }

            return totalPriorityValue;
        }
    }
}
