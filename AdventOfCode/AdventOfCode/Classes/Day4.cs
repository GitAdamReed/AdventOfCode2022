using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code.Classes
{
    public static class Day4
    {
        private static readonly string _filePath = "C:\\Users\\Adam\\Documents\\Sparta\\Advent of Code\\Advent_of_Code\\Advent_of_Code\\Text_Files\\Day4_Input.txt";

        private static int[][] ProcessLine(string line)
        {
            StringBuilder sb = new(line, 11);
            sb.Replace("-", ",");
            string[] processedString = sb.ToString().Split(",");
            List<int> numList = new();
            
            foreach (var item in processedString)
            {
                bool parsed = Int32.TryParse(item, out int parsedString);
                if (!parsed) throw new ArgumentException("Failed to parse string to int");
                numList.Add(parsedString);
            }

            int[][] finalArray = new int[2][];
            finalArray[0] = new int[] { numList[0], numList[1] };
            finalArray[1] = new int[] { numList[2], numList[3] };
            
            return finalArray;
        }

        public static int CheckFullSectionOverlap()
        {
            int overlapCount = 0;

            foreach (var line in File.ReadLines(_filePath))
            {
                int[][] sectionArray = ProcessLine(line);
                if (sectionArray[0][0] <= sectionArray[1][0] && sectionArray[0][1] >= sectionArray[1][1])
                {
                    overlapCount++;
                }
                else if (sectionArray[1][0] <= sectionArray[0][0] && sectionArray[1][1] >= sectionArray[0][1])
                {
                    overlapCount++;
                }
            }

            return overlapCount;
        }

        public static int CheckUniqueSectionOverlap()
        {
            int overlapCount = 0;

            foreach (var line in File.ReadLines(_filePath))
            {
                int[][] sectionArray = ProcessLine(line);
                if (sectionArray[0][0] >= sectionArray[1][0] && sectionArray[0][0] <= sectionArray[1][1])
                {
                    overlapCount++;
                }
                else if (sectionArray[0][1] <= sectionArray[1][1] && sectionArray[0][1] >= sectionArray[1][0])
                {
                    overlapCount++;
                }
                else if (sectionArray[1][0] >= sectionArray[0][0] && sectionArray[1][0] <= sectionArray[0][1])
                {
                    overlapCount++;
                }
                else if (sectionArray[1][1] <= sectionArray[0][1] && sectionArray[1][1] >= sectionArray[0][0])
                {
                    overlapCount++;
                }
            }

            return overlapCount;
        }

        public static void Test()
        {
            int[][] array = ProcessLine("22-77,14-96");
            foreach (var item in array)
            {
                foreach (var item2 in item)
                {
                    Console.WriteLine(item2);
                }
            }
        }
    }
}
