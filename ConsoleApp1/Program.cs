using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Program p = new Program();

            int[] data = { 10, 20, 20, 10, 10, 30, 50, 10, 20 };

            int result = p.TotalPairColour(data);

            Console.WriteLine($"Final result: {result}");

        }

        public int  TotalPairColour(int[] socksColor)
        {
            int count = 0;

            HashSet<int> data = new HashSet<int> ();

            foreach (int a in socksColor)
            {
                if (data.Contains(a))
                {
                    data.Remove(a);
                    count++;
                }
                else
                {
                    data.Add(a);
                }
            }

            return count;
        }
    }
}
