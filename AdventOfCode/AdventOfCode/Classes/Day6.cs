using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Classes
{
    public static class Day6
    {
        private static readonly string _datastream = File.ReadAllText("C:\\Users\\Adam\\Documents\\GitHub\\AdventOfCode2022\\AdventOfCode\\AdventOfCode\\Text_Files\\Day6_Input.txt");

        public static int FindStartOfPacketMarkerPosition()
        {
            char[] fourBitStream = new char[] { _datastream[0], _datastream[1], _datastream[2], _datastream[3] };
            
            bool found = false;
            int currentPos = 3;
            while (!found)
            {
                var distinctCollection = fourBitStream.Distinct();
                if (distinctCollection.Count() != 4)
                {
                    currentPos++;
                    fourBitStream[0] = fourBitStream[1];
                    fourBitStream[1] = fourBitStream[2];
                    fourBitStream[2] = fourBitStream[3];
                    fourBitStream[3] = _datastream[currentPos];
                }
                else
                {
                    found = true;
                }
            }
            
            return currentPos + 1;
        }

        public static int FindStartOfMessageMarkerPosition()
        {
            char[] fourteenBitStream = new char[14];

            for (int i = 0; i < fourteenBitStream.Length; i++)
            {
                fourteenBitStream[i] = _datastream[i];
            }

            bool found = false;
            int currentPos = 13;
            while (!found)
            {
                var distinctCollection = fourteenBitStream.Distinct();
                if (distinctCollection.Count() != 14)
                {
                    currentPos++;
                    for (int i = 0; i < fourteenBitStream.Length - 1; i++)
                    {
                        fourteenBitStream[i] = fourteenBitStream[i + 1];
                    }
                    fourteenBitStream[13] = _datastream[currentPos];
                }
                else
                {
                    found = true;
                }
            }

            return currentPos + 1;
        }
    }
}
