using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code.Classes
{
    public class Day5
    {
        private static string _filePath = "C:\\Users\\Adam\\Documents\\Sparta\\Advent of Code\\Advent_of_Code\\Advent_of_Code\\Text_Files\\Day5_Input.txt";

        #region Stacks
        private Stack<char> _stack1 = new Stack<char>(new char[] { 'N', 'B', 'D', 'T', 'V', 'G', 'Z', 'J' });
        private Stack<char> _stack2 = new Stack<char>(new char[] { 'S', 'R', 'M', 'D', 'W', 'P', 'F' });
        private Stack<char> _stack3 = new Stack<char>(new char[] { 'V', 'C', 'R', 'S', 'Z' });
        private Stack<char> _stack4 = new Stack<char>(new char[] { 'R', 'T', 'J', 'Z', 'P', 'H', 'G' });
        private Stack<char> _stack5 = new Stack<char>(new char[] { 'T', 'C', 'J', 'N', 'D', 'Z', 'Q', 'F' });
        private Stack<char> _stack6 = new Stack<char>(new char[] { 'N', 'V', 'P', 'W', 'G', 'S', 'F', 'M' });
        private Stack<char> _stack7 = new Stack<char>(new char[] { 'G', 'C', 'V', 'B', 'P', 'Q' });
        private Stack<char> _stack8 = new Stack<char>(new char[] { 'Z', 'B', 'P', 'N' });
        private Stack<char> _stack9 = new Stack<char>(new char[] { 'W', 'P', 'J' });
        private readonly Stack<char>[] _stackArray;
        #endregion

        private readonly List<int[]> _instructions = new();
        private readonly int _numOfInstructions;

        public Day5()
        {
            _stackArray = new Stack<char>[] { _stack1, _stack2, _stack3, _stack4, _stack5, _stack6, _stack7, _stack8, _stack9 };

            // Get instructions
            foreach (var line in File.ReadLines(_filePath))
            {
                string[] splitLine = line.Split(" ");
                int[] currentInstructions = new int[3];
                int i = 0;
                foreach (var item in splitLine)
                {
                    if (Int32.TryParse(item, out int num))
                    {
                        currentInstructions[i] = num;
                        i++;
                    }
                }
                _instructions.Add(currentInstructions);
                _numOfInstructions++;
            }
        }

        public string GetTopCrates()
        {
            // Moving the boxes according to input
            foreach (var instructions in _instructions)
            {
                int numToMove = instructions[0];
                int from = instructions[1] - 1;
                int to = instructions[2] - 1;

                for (int i = 0; i < numToMove; i ++)
                {
                    _stackArray[to].Push(_stackArray[from].Pop());
                }
            }

            // Get the box at the top of each stack and form a string
            string message = String.Empty;
            foreach (var stack in _stackArray)
            {
                message += stack.Pop();
            }

            return message;
        }

        public string GetTopCratesCrateMover9001()
        {
            // WHY DOESN'T THIS WORK!!!
            //List<List<char>> crateArrays = new();
            //foreach (var stack in _stackArray)
            //{
            //    crateArrays.Add(stack.ToArray().ToList());
            //}

            //foreach (var instructions in _instructions)
            //{
            //    int numToMove = instructions[0];
            //    int cratesRemaining = numToMove;
            //    int from = instructions[1] - 1;
            //    int to = instructions[2] - 1;
            //    List<char> cratesToMove = new();

            //    for (int i = 0; i < numToMove; i++)
            //    {
            //        crateArrays[to].Add(crateArrays[from][^cratesRemaining]);
            //        crateArrays[from].Remove(crateArrays[from][^cratesRemaining]);
            //        cratesRemaining--;
            //    }

            //    for (int i = 0; i < numToMove; i++)
            //    {
            //        cratesToMove.Add(crateArrays[from][^cratesRemaining]);
            //        cratesRemaining--;
            //    }
            //    crateArrays[to].AddRange(cratesToMove);
            //}

            foreach (var instructions in _instructions)
            {
                int numToMove = instructions[0];
                int from = instructions[1] - 1;
                int to = instructions[2] - 1;
                List<char> crateToMove = new();

                for (int i = 0; i < numToMove; i++)
                {
                   crateToMove.Add(_stackArray[from].Pop());
                }
                crateToMove.Reverse();
                crateToMove.ForEach(c => _stackArray[to].Push(c));
            }

            string message = String.Empty;
            foreach (var stack in _stackArray)
            {
                message += stack.Pop();
            }

            return message;
        }
    }
}
