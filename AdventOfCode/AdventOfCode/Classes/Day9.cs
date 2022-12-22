using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Classes
{
    public class Day9
    {
        private static readonly string _filePath = "D:\\GitHub\\AdventOfCode2022\\AdventOfCode\\AdventOfCode\\Text_Files\\Day9_Input.txt";
        private static int _numUniqueTailPositions;

        public int NumUniqueTailPositions
        {
            get { return _numUniqueTailPositions; }
        }

        public Day9()
        {
            SimulateRopeMotions();
        }

        private static void SimulateRopeMotions()
        {
            int[] headPos = new int[] { 0, 0 };
            int[] tailPos = new int[] { 0, 0 };
            List<int[]> tailPosUnique = new();

            foreach (var line in File.ReadLines(_filePath))
            {
                string[] splitLine = line.Split(" ");
                string direction = splitLine[0];
                bool parsed = Int32.TryParse(splitLine[1], out int numOfSteps);
                if (!parsed) throw new ArgumentException("Could not convert string to int");

                for (int i = 0; i < numOfSteps; i++)
                {
                    int difference = 0;
                    int tailPosIterator;
                    switch (direction)
                    {
                        case "L":
                            headPos[0]--;
                            tailPosIterator = tailPos[0];
                            while (headPos[0] != tailPosIterator)
                            {
                                tailPosIterator--;
                                difference++;
                            }
                            if (difference > 1)
                            {
                                tailPos[0] = headPos[0];
                                tailPos[1] = headPos[1];
                                tailPos[0]++;
                            }
                            break;
                        case "R":
                            headPos[0]++;
                            tailPosIterator = tailPos[0];
                            while (headPos[0] != tailPosIterator)
                            {
                                tailPosIterator++;
                                difference++;
                            }
                            if (difference > 1)
                            {
                                tailPos[0] = headPos[0];
                                tailPos[1] = headPos[1];
                                tailPos[0]--;
                            }
                            break;
                        case "U":
                            headPos[1]--;
                            tailPosIterator = tailPos[1];
                            while (headPos[1] != tailPosIterator)
                            {
                                tailPosIterator--;
                                difference++;
                            }
                            if (difference > 1)
                            {
                                tailPos[0] = headPos[0];
                                tailPos[1] = headPos[1];
                                tailPos[1]++;
                            }
                            break;
                        case "D":
                            headPos[1]++;
                            tailPosIterator = tailPos[1];
                            while (headPos[1] != tailPosIterator)
                            {
                                tailPosIterator++;
                                difference++;
                            }
                            if (difference > 1)
                            {
                                tailPos[0] = headPos[0];
                                tailPos[1] = headPos[1];
                                tailPos[1]--;
                            }
                            break;
                        default:
                            throw new Exception("Invalid direction");
                    }

                    if (!tailPosUnique.Exists(t => t[0] == tailPos[0] && t[1] == tailPos[1]))
                    {
                        tailPosUnique.Add(new int[] { tailPos[0], tailPos[1] });
                    }
                }
            }

            _numUniqueTailPositions = tailPosUnique.Count;
        }
    }
}
