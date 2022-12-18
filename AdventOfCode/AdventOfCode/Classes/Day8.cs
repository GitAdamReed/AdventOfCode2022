using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private static Tree[,] _treeMatrix = new Tree[99, 99];
        private static int _visibleCount;
        private static int _highestScenicScore;
        
        public static int VisibleCount
        {
            get 
            {
                CreateTreeMatrix();
                return _visibleCount; 
            }
        }
        public static int HighestScenicScore
        {
            get 
            {
                CreateTreeMatrix();
                return _highestScenicScore; 
            }
        }

        private class Tree
        {
            public int _size;
            public bool _IsVisibile = false;
            public int _scenicScore;
            public Tree(int size)
            {
                _size = size;
            }
        }

        private static Tree[,] CreateTreeMatrix()
        {
            _visibleCount = 0;
            var arrayOfSizes = File.ReadLines(_filePath).ToArray();

            // Initailse matrix
            for (int x = 0; x <= _treeMatrix.GetUpperBound(0); x++)
            {
                for (int y = 0; y <= _treeMatrix.GetUpperBound(1); y++)
                {
                    _treeMatrix[x, y] = new Tree(int.Parse(arrayOfSizes[x][y].ToString()));
                    // Set boundaries as visible
                    if (x == 0 || x == 98 || y == 0 || y == 98)
                    {
                        _treeMatrix[x, y]._IsVisibile = true;
                        _visibleCount++;
                    }
                }
            }

            // Find if trees are visible
            for (int y = 0; y <= _treeMatrix.GetUpperBound(1); y++)
            {
                int xHighest = 0;
                for (int x = 0; x <= _treeMatrix.GetUpperBound(0); x++)
                {
                    if (_treeMatrix[x, y]._size > xHighest)
                    {
                        xHighest = _treeMatrix[x, y]._size;
                        if (!_treeMatrix[x, y]._IsVisibile)
                        {
                            _treeMatrix[x, y]._IsVisibile = true;
                            _visibleCount++;
                        }
                    }
                }

                xHighest = 0;
                for (int x = _treeMatrix.GetUpperBound(0); x >= 0; x--)
                {
                    if (_treeMatrix[x, y]._size > xHighest)
                    {
                        xHighest = _treeMatrix[x, y]._size;
                        if (!_treeMatrix[x, y]._IsVisibile)
                        {
                            _treeMatrix[x, y]._IsVisibile = true;
                            _visibleCount++;
                        }
                    }
                }
            }

            for (int x = 0; x <= _treeMatrix.GetUpperBound(0); x++)
            {
                int yHighest = 0;
                for (int y = 0; y <= _treeMatrix.GetUpperBound(1); y++)
                {
                    if (_treeMatrix[x, y]._size > yHighest)
                    {
                        yHighest = _treeMatrix[x, y]._size;
                        if (!_treeMatrix[x, y]._IsVisibile)
                        {
                            _treeMatrix[x, y]._IsVisibile = true;
                            _visibleCount++;
                        }
                    }
                }

                yHighest = 0;
                for (int y = _treeMatrix.GetUpperBound(1); y >= 0; y--)
                {
                    if (_treeMatrix[x, y]._size > yHighest)
                    {
                        yHighest = _treeMatrix[x, y]._size;
                        if (!_treeMatrix[x, y]._IsVisibile)
                        {
                            _treeMatrix[x, y]._IsVisibile = true;
                            _visibleCount++;
                        }
                    }
                }
            }

            // Calculate scenic score for each tree
            for (int y = 0; y <= _treeMatrix.GetUpperBound(1); y++)
            {
                for (int x = 0; x <= _treeMatrix.GetUpperBound(0); x++)
                {
                    Tree tree = _treeMatrix[x, y];
                    int leftScore = 0;
                    int rightScore = 0;
                    int upScore = 0;
                    int downScore = 0;
                    bool viewBlocked = false;

                    int l = x - 1;
                    while (!viewBlocked && l >= 0)
                    {
                        if (_treeMatrix[l, y]._size >= tree._size)
                        {
                            viewBlocked = true;
                        }
                        leftScore++;
                        l--;
                    }

                    viewBlocked = false;
                    int r = x + 1;
                    while (!viewBlocked && r <= _treeMatrix.GetUpperBound(0))
                    {
                        if (_treeMatrix[r, y]._size >= tree._size)
                        {
                            viewBlocked = true;
                        }
                        rightScore++;
                        r++;
                    }

                    viewBlocked = false;
                    int u = y - 1;
                    while (!viewBlocked && u >= 0)
                    {
                        if (_treeMatrix[x, u]._size >= tree._size)
                        {
                            viewBlocked = true;
                        }
                        upScore++;
                        u--;
                    }

                    viewBlocked = false;
                    int d = y + 1;
                    while (!viewBlocked && d <= _treeMatrix.GetUpperBound(1))
                    {
                        if (_treeMatrix[x, d]._size >= tree._size)
                        {
                            viewBlocked = true;
                        }
                        downScore++;
                        d++;
                    }

                    _treeMatrix[x, y]._scenicScore = upScore * leftScore * downScore * rightScore;
                    if (_treeMatrix[x, y]._scenicScore > _highestScenicScore)
                    {
                        _highestScenicScore = _treeMatrix[x, y]._scenicScore;
                    }
                }
            }

            return _treeMatrix;
        }
    }
}
