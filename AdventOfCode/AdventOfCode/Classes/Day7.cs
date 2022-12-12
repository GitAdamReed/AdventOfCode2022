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

        private class Directory
        {
            public string name;
            public int size = 0;
        }

        private static List<Directory> GetDirSizes()
        {
            List<Directory> directories = new();
            Stack<Directory> currentDirs = new();

            foreach (var line in File.ReadLines(_filePath))
            {
                string[] splitLine = line.Split(" ");
                if (splitLine[1] == "cd" && splitLine[2] != "..")
                {
                    Directory newDirectory = new()
                    {
                        name = splitLine[2]
                    };
                    directories.Add(newDirectory);
                    currentDirs.Push(newDirectory);
                }
                else if (splitLine[1] == "cd" && splitLine[2] == "..")
                {
                    currentDirs.Pop();
                }
                else if (Int32.TryParse(splitLine[0], out int fileSize))
                {
                    foreach (var dir in directories)
                    {
                        foreach (var currentDir in currentDirs)
                        {
                            if (currentDir == dir)
                            {
                                dir.size += fileSize;
                            }
                        }
                    }
                }
            }

            return directories;
        }

        public static int SumOfDirSizesUnder100000()
        {
            var directories = GetDirSizes();

            int totalFileSize = 0;
            foreach (var dir in directories)
            {
                if (dir.size <= 100000)
                {
                    totalFileSize += dir.size;
                }
            }

            return totalFileSize;
        }

        public static int SizeOfDirToDelete()
        {
            var directories = GetDirSizes();
            int totalSpace = 70000000;
            int updateSize = 30000000;
            int spaceUsed = directories.Find(d => d.name == "/").size;
            int spaceAvailable = totalSpace - spaceUsed;
            int spaceNeeded = updateSize - spaceAvailable;

            int lowestDir = spaceUsed;
            int lowestSize = Int32.MaxValue;
            foreach (var dir in directories)
            {
                int newSize = dir.size - spaceNeeded;
                if (newSize >= 0 && newSize < lowestSize)
                {
                    lowestDir = dir.size;
                    lowestSize = newSize;
                }
            }

            return lowestDir;
        }
    }
}
