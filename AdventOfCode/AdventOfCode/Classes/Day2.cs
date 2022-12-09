using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code.Classes
{
    public static class Day2
    {
        private enum RockPaperScissors
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3
        }

        private enum OpponentsMove
        {
            A = RockPaperScissors.Rock,
            B = RockPaperScissors.Paper,
            C = RockPaperScissors.Scissors
        }

        private enum MyMove
        {
            X = RockPaperScissors.Rock,
            Y = RockPaperScissors.Paper,
            Z = RockPaperScissors.Scissors
        }

        private static int GameLogic(OpponentsMove oppMove, MyMove myMove)
        {
            RockPaperScissors oppRPS = (RockPaperScissors)oppMove;
            RockPaperScissors myRPS = (RockPaperScissors)myMove;
            int score = (int)myRPS;

            if (oppRPS == RockPaperScissors.Rock && myRPS == RockPaperScissors.Paper)
            {
                score += 6;
            }
            else if (oppRPS == RockPaperScissors.Paper && myRPS == RockPaperScissors.Scissors)
            {
                score += 6;
            }
            else if (oppRPS == RockPaperScissors.Scissors && myRPS == RockPaperScissors.Rock)
            {
                score += 6;
            }
            else if (oppRPS == myRPS)
            {
                score += 3;
            }

            return score;
        }

        public static int PlayRockPaperScissors()
        {
            string filePath = "C:\\Users\\Adam\\Documents\\Sparta\\Advent of Code\\Advent_of_Code\\Advent_of_Code\\Text_Files\\Day2_Input.txt";
            int score = 0;

            foreach (var line in File.ReadLines(filePath))
            {
                string[] currentLine = line.Split(" ");
                bool oppMoveConverted = Enum.TryParse<OpponentsMove>(currentLine[0], out OpponentsMove oppMove);
                bool myMoveConverted = Enum.TryParse<MyMove>(currentLine[1], out MyMove myMove);

                // Check if text was successfully converted to enum
                if (!oppMoveConverted || !myMoveConverted)
                {
                    throw new ArgumentException("Could not convert enum to string");
                }

                // Part 2 - myMove now means how the round has to end
                // X = Lose
                // Y = Draw
                // Z = Win
                RockPaperScissors oppRPS = (RockPaperScissors)oppMove;
                RockPaperScissors myRPS = (RockPaperScissors)myMove;

                // Lose
                if (myMove == MyMove.X)
                {
                    if (oppRPS == myRPS)
                    {
                        myMove = MyMove.Z;
                    }
                    else if (oppRPS == RockPaperScissors.Scissors)
                    {
                        myMove = MyMove.Y;
                    }
                }
                // Win
                else if (myMove == MyMove.Z)
                {
                    if (oppRPS == myRPS)
                    {
                        myMove = MyMove.X;
                    }
                    else if (oppRPS == RockPaperScissors.Rock)
                    {
                        myMove = MyMove.Y;
                    }
                }
                // Draw
                else
                {
                    myRPS = oppRPS;
                    myMove = (MyMove)myRPS;
                }
                    
                // Call GameLogic and get score
                score += GameLogic(oppMove, myMove);
            }

            return score;
        }
    }
}
