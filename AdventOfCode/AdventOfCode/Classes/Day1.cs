using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code.Classes
{
    public static class Day1
    {
        private static List<int> _listOfSums = new List<int>();

        public static void CalculateSums()
        {
            int sum = 0;
            string filePath = "C:\\Users\\Adam\\Documents\\Sparta\\Advent of Code\\Advent_of_Code\\Advent_of_Code\\Text_Files\\Day1_Input.txt";

            foreach (string line in File.ReadLines(filePath))
            {
                int currentNum;

                if (line == string.Empty)
                {
                    _listOfSums.Add(sum);
                    sum = 0;
                }
                else
                {
                    currentNum = int.Parse(line);
                    sum += currentNum;
                }
            }
        }

        public static int ElfWithMostCaloriesSum()
        {
            // Get highest number in list
            int highest = 0;
            foreach (int num in _listOfSums)
            {
                if (num > highest)
                {
                    highest = num;
                }
            }

            return highest;
        }

        public static int TopThreeElvesWithMostCaloriesSum()
        {
            List<int> sortedList = _listOfSums;
            sortedList.Sort();
            sortedList.Reverse();
            int sum = 0;

            for (int i = 0; i < 3; i++)
            {
                sum += sortedList[i];
            }

            return sum;
        }
    }
}
