using System;
using System.Linq;

namespace MoveZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Input: [0, 1, 0, 3, 12]
            //Output: [1, 3, 12, 0, 0]
            //[0,0,1]

            int[] data = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
            //int[] data = { 0, 1, 0, 3, 12};

            Console.WriteLine("Move Zeroes: [" + string.Join(", ", MoveZeroes(data).ToArray()) + "]");
        }

        public static int[] MoveZeroes(int[] nums)
        {
            int j = nums.Length;
            int nonZeros = 0;

            for (int i = 0; i < j; i++)
            {
                //if it non-zeros, move it the space of nonZeros and count it
                if (nums[i] != 0)
                {
                    nums[nonZeros++] = nums[i]; //increase execute after assigning
                }
            }

            while (nonZeros < j)
            {
                nums[nonZeros++] = 0;
            }

            return nums;
        }
    }
}
