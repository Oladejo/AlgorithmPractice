using System;

namespace PerformStringShifts
{
    class Program
     {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string s = "abc";
            int[][] data = new int[][]  { new int[] { 0, 1}, new int[] {1,2 } };

            string s1 = "abcdefg";
            int[][] data1 = new int[][] { new int[] { 1, 1}, new int[] { 1, 1}, new int[] {0, 2 }, new int[] { 1, 3} };

            Console.WriteLine(StringShift(s, data));
            Console.WriteLine(StringShift(s1, data1));

            string s2 = "wpdhhcj";
            int[][] data2 = new int[][] { new int[] { 0, 7 }, new int[] { 1, 7 }, new int[] { 1, 0 }, new int[] { 1, 3 }, new int[] { 0, 3 }, new int[] { 0, 6 }, new int[] { 1, 2 } };
            Console.WriteLine(StringShift(s2, data2));

            //"hcjwpdh"

            //"yisxjwry"
            //[[1, 8],[1,4],[1,3],[1,6],[0,6],[1,4],[0,2],[0,1]]

            string s3 = "yisxjwry";
            int[][] data3 = new int[][] { new int[] { 1, 8 }, new int[] { 1, 4 }, new int[] { 1, 3 }, new int[] { 1, 6 }, new int[] { 0, 6 }, new int[] { 1, 4 }, new int[] { 0, 2 }, new int[] { 0, 1 } };

            Console.WriteLine(StringShift(s3, data3));

        }

        public static string StringShift(string s, int[][] shift)
        {
            int totalShift = 0;

            foreach (int[] a in shift)
            {
                int direction = a[0];
                int amount = a[1];

                if (direction == 0)
                {
                    totalShift += amount;
                }
                else
                {
                    totalShift -= amount;
                }
            }

            string frontShift;
            string backShift;

            if (totalShift > s.Length || -totalShift > s.Length)
            {
                totalShift %= s.Length;
            }            
            
            if(totalShift < 0) {
                totalShift = s.Length + totalShift;
            }

            frontShift = s.Substring(totalShift);
            backShift = s.Substring(0, totalShift);
            return frontShift + backShift;
        }

        public static string StringShift2(string s, int[][] shift)
        {
            int totalShift = 0;

            foreach (int[] a in shift)
            {
                totalShift += (a[0] == 0) ? a[1] : -a[1];
            }

            if (totalShift > s.Length || -totalShift > s.Length)
            {
                totalShift %= s.Length;
            }

            if (totalShift < 0)
            {
                totalShift += s.Length;
            }
            return s.Substring(totalShift) + s.Substring(0, totalShift);
        }          
    
    }
}


//  You are given a string s containing lowercase English letters, and a matrix shift, where shift[i] = [direction, amount]:
//direction can be 0 (for left shift) or 1 (for right shift). 
//amount is the amount by which string s is to be shifted.
//A left shift by 1 means remove the first character of s and append it to the end.
//Similarly, a right shift by 1 means remove the last character of s and add it to the beginning.
//Return the final string after all operations.

//Example 1
//   Input: s = "abc", shift = [[0,1],[1,2]]
//Output: "cab"
//Explanation: 
//[0,1] means shift to left by 1. "abc" -> "bca"
//[1,2] means shift to right by 2. "bca" -> "cab"

//Example 2
//Input: s = "abcdefg", shift = [[1,1],[1,1],[0,2],[1,3]]
//Output: "efgabcd"
//Explanation:  
//[1,1] means shift to right by 1. "abcdefg" -> "gabcdef"
//[1,1] means shift to right by 1. "gabcdef" -> "fgabcde"
//[0,2] means shift to left by 2. "fgabcde" -> "abcdefg"
//[1,3] means shift to right by 3. "abcdefg" -> "efgabcd"
