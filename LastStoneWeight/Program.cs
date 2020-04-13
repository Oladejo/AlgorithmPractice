using C5;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LastStoneWeight
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //int[] arr = { 1, 2, 3, 1 };
            int[] arr2 = { 2, 7, 4, 1, 8, 1, 1 };
            //Console.WriteLine($"Result: {LastStoneWeight(arr)}");
            Console.WriteLine($"Result: {LastStoneWeight(arr2)}");

            //Console.WriteLine($"Result: {LastStoneWeightHeap(arr)}");
            Console.WriteLine($"Result: {LastStoneWeightHeap(arr2)}");
        }

        public static int LastStoneWeightHeap(int[] stones)
        {
            int arrLenght = stones.Length;
            IntervalHeap<int> heap = new IntervalHeap<int>();

            //1 <= stones.length <= 30
            if (arrLenght == 0 || arrLenght > 30)
            {
                throw new Exception("Data must satisfy the constraints");
            }

            //1 <= stones[i] <= 1000
            foreach (int i in stones)
            {
                if (i > 1000)
                {
                    throw new Exception("Data must satisfy the constraints");
                }
                heap.Add(i);
            }

            while (heap.Count > 1)
            {
                int firstMax = heap.FindMax();
                heap.DeleteMax();

                int SecondMax = heap.FindMax();
                heap.DeleteMax();

                if(firstMax > SecondMax)
                {
                    heap.Add(firstMax - SecondMax);
                }
            }

            return heap.Count == 0 ? 0 : heap.FindMin();
        }

        //use sorted list since I cannot use interval heap on leetcode
        public static int LastStoneWeight(int[] stones)
        {
            int arrLenght = stones.Length;
            List<int> heap = new List<int>();

            //1 <= stones.length <= 30
            if (arrLenght == 0 || arrLenght > 30)
            {
                throw new Exception("Data must satisfy the constraints");
            }

            //1 <= stones[i] <= 1000
            foreach (int i in stones)
            {
                if (i > 1000)
                {
                    throw new Exception("Data must satisfy the constraints");
                }
                heap.Add(i);
            }

            while (heap.Count > 1)
            {
                int firstMax = heap.Max();
                heap.Remove(firstMax);

                int SecondMax = heap.Max();
                heap.Remove(SecondMax);

                if (firstMax > SecondMax)
                {
                    heap.Add(firstMax - SecondMax);
                }
            }

            return heap.FirstOrDefault();
        }
    }
}
