using System.Collections.Generic;
using System.IO;
using System;

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'twoPluses' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING_ARRAY grid as parameter.
     */

    public static int twoPluses(List<string> grid)
    {
        int maxsize = 0;
        int[] maxPos = new int[2];
        int res = 1;
        for (int i = 1; i < grid.Count-1; i++)
        {
            for (int j = 1; j < grid[i].Length-1; j++)
            {
                if (grid[i][j] == 'B' || grid[i][j] == 'P')
                {
                    continue;
                }
                int x = i;
                int y = j;
                while (grid[x][y] != 'B' && grid[x][y] != 'P')
                {
                    x++;
                    if (x==grid.Count-1)
                    {
                        break;
                    }
                }
                int size = x - i-1;
                x = i;
                while (grid[x][y] != 'B' && grid[x][y] != 'P')
                {
                    x--;
                    if (x == -1)
                    {
                        break;
                    }
                }
                size = Math.Min(size, i-x-1);
                x = i;
                while (grid[x][y] != 'B' && grid[x][y] != 'P')
                {
                    y++;
                    if (y == grid[i].Length)
                    {
                        break;
                    }
                }
                size = Math.Min(size, y - j-1);
                y = j;
                while (grid[x][y] != 'B' && grid[x][y] != 'P')
                {
                    y--;
                    if (y == -1)
                    {
                        break;
                    }
                }
                size = Math.Min(size, j - y-1);
                if (size > maxsize)
                {
                    maxsize = size;
                    maxPos = new int[] { i, j };
                }
            }
        }

        res *= (maxsize*4+1);
        for (int i = maxPos[0] -maxsize; i <= maxPos[0]+maxsize; i++)
        {
            StringBuilder sb = new StringBuilder(grid[i]);
            sb[maxPos[1]] = 'P';
            grid[i] = sb.ToString();
        }

        for (int i = maxPos[1] - maxsize; i <= maxPos[1] + maxsize; i++)
        {
            StringBuilder sb = new StringBuilder(grid[maxPos[0]]);
            sb[i] = 'P';
            grid[maxPos[0]] = sb.ToString();
        }

        maxsize = 0;
        for (int i = 1; i < grid.Count - 1; i++)
        {
            for (int j = 1; j < grid[i].Length - 1; j++)
            {
                if (grid[i][j] == 'B' || grid[i][j] == 'P')
                {
                    continue;
                }
                int x = i;
                int y = j;
                while (grid[x][y] != 'B' && grid[x][y] != 'P')
                {
                    x++;
                    if (x == grid.Count - 1)
                    {
                        break;
                    }
                }
                int size = x - i - 1;
                x = i;
                while (grid[x][y] != 'B' && grid[x][y] != 'P')
                {
                    x--;
                    if (x == -1)
                    {
                        break;
                    }
                }
                size = Math.Min(size, i - x - 1);
                x = i;
                while (grid[x][y] != 'B' && grid[x][y] != 'P')
                {
                    y++;
                    if (y == grid[i].Length)
                    {
                        break;
                    }
                }
                size = Math.Min(size, y - j - 1);
                y = j;
                while (grid[x][y] != 'B' && grid[x][y] != 'P')
                {
                    y--;
                    if (y == -1)
                    {
                        break;
                    }
                }
                size = Math.Min(size, j - y - 1);
                if (size > maxsize)
                {
                    maxsize = size;
                    maxPos = new int[] { i, j };
                }
            }
        }

        res *= (maxsize * 4 + 1);
        return res;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<string> grid = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string gridItem = Console.ReadLine();
            grid.Add(gridItem);
        }

        int result = Result.twoPluses(grid);

        Console.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
