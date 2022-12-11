using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Classes
{
    public static class Day7
    {
        private static string _filePath = "C:\\Users\\Adam\\Documents\\GitHub\\AdventOfCode2022\\AdventOfCode\\AdventOfCode\\Text_Files\\Day7_Input.txt";

        public static int SumOfDirSizesUnder100000()
        {
            Dictionary<string, int> directories = new();
            List<string> currentDirs = new();
            List<string> filesAdded = new();

            foreach (var line in File.ReadLines(_filePath))
            {
                string[] splitLine = line.Split(" ");
                if (splitLine[1] == "cd" && splitLine[2] != "..")
                {
                    if (!directories.ContainsKey(splitLine[2]))
                    {
                        directories.Add(splitLine[2], 0);
                    }
                    currentDirs.Add(splitLine[2]);

                }
                else if (splitLine[1] == "cd" && splitLine[2] == "..")
                {
                    currentDirs.Remove(currentDirs[^1]);
                }
                else if (Int32.TryParse(splitLine[0], out int fileSize))
                {
                    string? file = filesAdded.Find(f => f == splitLine[1]);
                    if (file == null)
                    {
                        foreach (var dir in currentDirs)
                        {
                            if (directories.ContainsKey(dir))
                            {
                                directories[dir] += fileSize;
                            }
                        }
                        filesAdded.Add(splitLine[1]);
                    }
                }
            }

            int totalFileSize = 0;
            foreach (var kvp in directories)
            {
                if (kvp.Value <= 100000)
                {
                    totalFileSize += kvp.Value;
                }
            }

            return totalFileSize;
        }
    }
}
