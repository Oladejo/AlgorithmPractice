using System;
using System.Collections.Generic;
using System.Linq;

namespace Two_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            int[] nums = { 2, 7, 11, 15 };
            int target = 9;

            Program p = new Program();

            var result = p.TwoSum(nums, target);

            Console.WriteLine("Indices of Two Sum: [" + string.Join(", ", result.ToArray()) + "]");
        }

        public int[] TwoSum2(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == target - nums[i])
                    {
                        return new int[] { i, j };
                    }
                }
            }

            throw new Exception("No two sum value in your data");
        }

        public int[] TwoSum1(int[] nums, int target)
        {
            Dictionary<int, int> mapDifferentWithIndex = new Dictionary<int, int>();
            int different = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                different = target - nums[i];
                
                if (mapDifferentWithIndex.ContainsValue(different))
                {
                    return new int[]
                    {
                        mapDifferentWithIndex.FirstOrDefault(x => x.Value == different).Key, i
                    };
                }
                mapDifferentWithIndex.Add(i, nums[i]);
            }

            throw new Exception("No two sum value in your data");
        }

        //failed
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> mapDifferentWithIndex = new Dictionary<int, int>();
            int different = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                different = target - nums[i];                

                if (mapDifferentWithIndex.TryGetValue(different, out int value))
                {
                    return new int[]
                    {
                        value, i
                    };
                }
                mapDifferentWithIndex.Add(nums[i], i);
            }

            throw new Exception("No two sum value in your data");
        }

    }
}
