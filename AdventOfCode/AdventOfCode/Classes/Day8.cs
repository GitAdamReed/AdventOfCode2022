using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace AdventOfCode.Classes
{
    public static class Day8
    {
        private static string _filePath = "C:\\Users\\Adam\\Documents\\GitHub\\AdventOfCode2022\\AdventOfCode\\AdventOfCode\\Text_Files\\Day8_Input.txt";
        private static int _visibleCount = 0;


        private class Tree
        {
            public int _size;
            public bool _IsVisibile = false;
            public Tree(int size)
            {
                _size = size;
            }
        }

        private static Tree[,] CreateTreeMatrix()
        {
            Tree[,] treeMatrix = new Tree[99, 99];
            var arrayOfSizes = File.ReadLines(_filePath).ToArray();

            // Initailse matrix
            for (int x = 0; x <= treeMatrix.GetUpperBound(0); x++)
            {
                for (int y = 0; y <= treeMatrix.GetUpperBound(1); y++)
                {
                    treeMatrix[x, y] = new Tree(Int32.Parse(arrayOfSizes[x][y].ToString()));
                    // Set boundaries as visible
                    if (x == 0 || x == 98 || y == 0 || y == 98)
                    {
                        treeMatrix[x, y]._IsVisibile = true;
                        _visibleCount++;
                    }
                }
            }

            return treeMatrix;
        }

        public static int GetVisibleTreesCount()
        {
            var matrix = CreateTreeMatrix();

            for (int y = 0; y <= matrix.GetUpperBound(1); y++)
            {
                int xHighest = 0;
                for (int x = 0; x <= matrix.GetUpperBound(0); x++)
                {
                    if (matrix[x, y]._size > xHighest)
                    {
                        xHighest = matrix[x, y]._size;
                        if (!matrix[x, y]._IsVisibile)
                        {
                            matrix[x, y]._IsVisibile = true;
                            _visibleCount++;
                        }
                    }
                }
                
                xHighest = 0;
                for (int x = matrix.GetUpperBound(0); x >= 0; x--)
                {
                    if (matrix[x, y]._size > xHighest)
                    {
                        xHighest = matrix[x, y]._size;
                        if (!matrix[x, y]._IsVisibile)
                        {
                            matrix[x, y]._IsVisibile = true;
                            _visibleCount++;
                        }
                    }
                }
            }
            
            for (int x = 0; x <= matrix.GetUpperBound(0); x++)
            {
                int yHighest = 0;
                for (int y = 0; y <= matrix.GetUpperBound(1); y++)
                {
                    if (matrix[x, y]._size > yHighest)
                    {
                        yHighest = matrix[x, y]._size;
                        if (!matrix[x, y]._IsVisibile)
                        {
                            matrix[x, y]._IsVisibile = true;
                            _visibleCount++;
                        }
                    }
                }

                yHighest = 0;
                for (int y = matrix.GetUpperBound(1); y >= 0; y--)
                {
                    if (matrix[x, y]._size > yHighest)
                    {
                        yHighest = matrix[x, y]._size;
                        if (!matrix[x, y]._IsVisibile)
                        {
                            matrix[x, y]._IsVisibile = true;
                            _visibleCount++;
                        }
                    }
                }
            }

            return _visibleCount;
        }

        public static void Test()
        {
            CreateTreeMatrix();
        }
    }
}
