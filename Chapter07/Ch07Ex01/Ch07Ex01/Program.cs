﻿using System;
using System.Diagnostics;

namespace Ch07Ex01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] testArray = { 4, 7, 4, 2, 7, 3, 7, 8, 3, 9, 1, 9 };
            int maxVal = Maxima(testArray, out int[] maxValIndices);
            Console.WriteLine($"Maximum value {maxVal} found at element indices:");
            foreach (int index in maxValIndices)
            {
                Console.WriteLine(index);
            }
            Console.ReadKey();
        }
        static int Maxima(int[] integers, out int[] indices)
        {
            Debug.WriteLine("Maximum value search started.");
            indices = new int[1];
            int maxVal = integers[0];
            indices[0] = 0;
            int count = 1;
            Debug.WriteLine(String.Format($"Maximum value initialized to {maxVal}, at element index {indices[0]}."));
            for (int i = 1; i < integers.Length; i++)
            {
                Debug.WriteLine($"Now looking at element at index {i}.");
                if (integers[i] > maxVal)
                {
                    maxVal = integers[i];
                    count = 1;
                    indices = new int[1];
                    indices[0] = i;
                    Debug.WriteLine($"New maximum found. New value is {maxVal}, at element index {i}.");
                }
                else
                {
                    if (integers[i] == maxVal)
                    {
                        count++;
                        int[] oldIndices = indices;
                        indices = new int[count];
                        oldIndices.CopyTo(indices, 0);
                        indices[count - 1] = i;
                        Debug.WriteLine($"Duplicate maximum found at element index {i}.");
                    }
                }
            }
            Trace.WriteLine($"Maximum value {maxVal} found, with {count} occurences.");
            Debug.WriteLine("Maximum value search completed.");
            return maxVal;
        }

    }
}
