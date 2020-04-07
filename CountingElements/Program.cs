using System;
using System.Collections.Generic;

namespace CountingElements
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] arr = { 1, 2, 3 };
            int[] arr1 = { 1, 1, 3, 3, 5, 5, 7, 7 };
            int[] arr2 = { 1, 3, 2, 3, 5, 0 };
            int[] arr4 = { 1, 1, 2, 2 };
          // int[] arr5 = { };
            int[] arr6 = { 1, 1, 2, 2, 2000, 3000};

            Console.WriteLine($"Result: {CountElements(arr)}");
            Console.WriteLine($"Result: {CountElements(arr1)}");
            Console.WriteLine($"Result: {CountElements(arr2)}");
            Console.WriteLine($"Result: {CountElements(arr4)}");
            //Console.WriteLine($"Result: {CountElements(arr5)}");
            Console.WriteLine($"Result: {CountElements(arr6)}");

        }

        public static int CountElements(int[] arr)
        {
            int arrLenght = arr.Length;

            if(arrLenght == 0 || arrLenght > 1000)
            {
                throw new Exception("Data must satisfy the constraints");
            }

            HashSet<int> data = new HashSet<int>();
            int count = 0;
            foreach (int i in arr)
            {
                if(i > 1000)
                {
                    throw new Exception("Data must satisfy the constraints");
                }

                if (!data.Contains(i))
                {
                    data.Add(i);
                }
            }

            foreach(int i in arr)
            {
                int check = i + 1;
                if (data.Contains(check))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
