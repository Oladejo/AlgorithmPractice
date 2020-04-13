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
            //Console.WriteLine($"Result: {LastStoneWeightHeap(arr2)}");
            Console.WriteLine($"Result: {LastStoneWeightUsinfCustomHeap(arr2)}");
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

        public static int LastStoneWeightUsinfCustomHeap(int[] stones)
        {
            BuildMaxHeap(stones);
            while (stones.Length > 1)
            {
                int stone1 = ExtractMax(ref stones);
                int stone2 = ExtractMax(ref stones);

                if (stone1 - stone2 != 0)
                    AddToMaxHeap(ref stones, (stone1 - stone2));
            }

            if (stones.Length == 0)
                return 0;
            else
                return ExtractMax(ref stones);
        }

        public static void MaxHeapify(int[] A, int i) //Assuming array A is 0 based (not 1 based)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            if (l < A.Length && A[l] > A[largest])
                largest = l;
            if (r < A.Length && A[r] > A[largest])
                largest = r;
            if (largest != i)
            {
                int temp = A[i];
                A[i] = A[largest];
                A[largest] = temp;
                MaxHeapify(A, largest);
            }
        }

        public static void BuildMaxHeap(int[] A)
        {
            for (int i = A.Length / 2; i >= 0; i--)
            {
                MaxHeapify(A, i);
            }
        }

        public static int ExtractMax(ref int[] A)
        {
            if (A.Length == 1)
            {
                int retVal = A[0];
                A = new int[0];
                return retVal;
            }

            int root = A[0];
            A[0] = A[A.Length - 1];
            A = A.Take(A.Length - 1).ToArray();
            MaxHeapify(A, 0);
            return root;

        }

        public static void AddToMaxHeap(ref int[] A, int num)
        {
            Array.Resize(ref A, A.Length + 1);
            A[A.Length - 1] = num;
            BuildMaxHeap(A);
        }
    }
}
