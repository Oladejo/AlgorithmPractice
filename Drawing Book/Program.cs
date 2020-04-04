using System;

namespace Drawing_Book
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int n = 6;  //Number of pages in the book
            int p = 2; //Page looking for

            int result = PageCount(n, p);

            Console.WriteLine($"Minumum number of page turns = {result}");
        }

        /*
     * Complete the pageCount function below.
     */
        static int PageCount(int n, int p)
        {
            int count = 0;

            if (p == 1 || p == n)
            {
                return count;
            }
                        
            else if(p <= n / 2)
            {
                //start counting from front
                count = CountFromFront(n / 2, p);
            }
            else
            {
                //start count from back
                count = CountFromBack(n, p);
            }

           
            return count;
        }

        static int CountFromFront(int n, int p)
        {
            int x = 1; //startPoint
            int y = 0; //hold the 2nd number on the page
            int count = 0;

            while(x < n)
            {
                count += 1;
                x += 1;
                y = x + 1;
                if (p == x || p == y) return count;

                x = y;
            }

            return count;
        }

        static int CountFromBack(int n, int p)
        {
            int count = 0;
            int y = 0;
            
            while (n > p)
            {

                if(n % 2 == 0)
                {
                    y = n + 1;
                }
                else
                {
                    y = n - 1;
                }
                
                if (p == n || p == y) return count;

                count += 1;
                n -= 2;
            }

            return count;
        }
    }
}
