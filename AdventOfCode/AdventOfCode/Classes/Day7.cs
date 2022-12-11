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
            Dictionary<string, List<string>> filesAdded = new();

            foreach (var line in File.ReadLines(_filePath))
            {
                string[] splitLine = line.Split(" ");
                if (splitLine[1] == "cd" && splitLine[2] != "..")
                {
                    if (splitLine[2] == "vsqjb")
                    {

                    }

                    if (currentDirs.Find(f => f == splitLine[2]) != null)
                    {
                        int affix = 0;
                        foreach (var dir in currentDirs)
                        {
                            if (dir == splitLine[2]) affix++;
                        }

                        splitLine[2] += affix;
                    }
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
                    string file = splitLine[1];
                    bool duplicate = false;
                    bool dirExists = false;
                    foreach (var kvp in filesAdded)
                    {
                        if (kvp.Key == currentDirs[^1])
                        {
                            if (kvp.Value.Find(f => f == file) != null) duplicate = true;
                            else kvp.Value.Add(file);
                            dirExists = true;
                        }
                    }
                    if (!duplicate)
                    {
                        foreach (var dir in currentDirs)
                        {
                            if (directories.ContainsKey(dir))
                            {
                                directories[dir] += fileSize;
                            }
                        }
                    }
                    if (!dirExists)
                    {
                        string dirName = currentDirs[^1];
                        if (filesAdded.ContainsKey(dirName))
                        {
                            int affix = 0;
                            foreach (var kvp in filesAdded)
                            {
                                if (kvp.Key == dirName) affix++;
                            }
                        }
                        filesAdded.Add(dirName, new List<string>() { file });
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
