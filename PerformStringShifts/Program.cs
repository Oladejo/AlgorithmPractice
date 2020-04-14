using System;

namespace PerformStringShifts
{
    class Program
     {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string s = "abc";
            int[][] data = new int[][]
            {
                new int[] { 0, 1},
                new int[] {1,2 }
            };
            //[[0,1],[1,2]]
            //s = , shift = [[1, 1],[1,1],[0,2],[1,3]]

            string s1 = "abcdefg";
            int[][] data1 = new int[][]
            {
                new int[] { 1, 1},
                new int[] { 1, 1},
                new int[] {0, 2 },
                new int[] { 1, 3}
            };

            Console.WriteLine(StringShift(s, data));
            Console.WriteLine(StringShift(s1, data1));
        }


        public static string StringShift(string s, int[][] shift)
        {
            int totalShift = 0;

            for (int i = 0; i < shift.Length; i++)
            {
                int direction = shift[i][0];
                int amount = shift[i][1];

                if (direction == 0)
                {
                    //left shift
                    totalShift -= amount;
                }
                else
                {
                    //right shift
                    totalShift += amount;
                }
            }

            string frontShift;
            string backShift;

            if (totalShift < 0)
            {
                //left shit
                frontShift = s.Substring(totalShift);
                backShift = s.Substring(0, totalShift);
            }
            else if (totalShift > 0)
            {
                //right shift
                frontShift = s.Substring(s.Length - totalShift, totalShift);
                backShift = s.Substring(0, s.Length - totalShift);
            }
            else
            {
                //no shift
                return s;
            }

            return frontShift + backShift;
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
