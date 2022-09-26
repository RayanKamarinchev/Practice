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
     * Complete the 'matrixRotation' function below.
     *
     * The function accepts following parameters:
     *  1. 2D_INTEGER_ARRAY matrix
     *  2. INTEGER r
     */
    public static int[] Next(int x, int y, int maX, int maxY, int i, int r)
    {
        for (int j = 0; j < r; j++)
        {
            if (y == i)
            {
                if (x == maX - i)
                {
                    y++;
                }
                else
                {
                    x++;
                }
            }
            else if (x == i)
            {
                if (y == i)
                {
                    x++;
                }
                else
                {
                    y--;
                }
            }
            else if (y == maxY - i)
            {
                if (x == i)
                {
                    y--;
                }
                else
                {
                    x--;
                }
            }
            else if (x == maX - i)
            {
                if (y == maxY - i)
                {
                    x--;
                }
                else
                {
                    y++;
                }
            }
        }

        return new int[] { x, y };
    }

    public static void matrixRotation(List<List<int>> matrix, int r)
    {
        int x = matrix.Count;
        int y = matrix[0].Count;
        List<List<int>> newMatrix = new List<List<int>>();
        for (int i = 0; i < x; i++)
        {
            newMatrix.Add(new List<int>());
            for (int j = 0; j < y; j++)
            {
                newMatrix[i].Add(matrix[i][j]);
            }
        }

        for (int i = 0; i < Math.Min(x, y) / 2; i++)
        {
            for (int j = i; j < x - i; j++)
            {
                for (int k = i; k < y - i; k++)
                {
                    if (k == i || j == i || k == y - i - 1 || j == x - i - 1)
                    {
                        var pos = Next(j, k, x - 1, y - 1, i, r);
                        newMatrix[pos[0]][pos[1]] = matrix[j][k];
                    }
                }
            }
        }

        newMatrix.ForEach(m=>Console.WriteLine(string.Join(' ', m)));
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int m = Convert.ToInt32(firstMultipleInput[0]);

        int n = Convert.ToInt32(firstMultipleInput[1]);

        int r = Convert.ToInt32(firstMultipleInput[2]);

        List<List<int>> matrix = new List<List<int>>();

        for (int i = 0; i < m; i++)
        {
            matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
        }

        Result.matrixRotation(matrix, r);
    }
}