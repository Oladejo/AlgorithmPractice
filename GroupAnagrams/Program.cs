using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupAnagrams
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");

            string[] data = { "eat", "tea", "tan", "ate", "nat", "bat" };

            var result = GroupAnagrams(data);

            foreach(var i in result)
            {
                Console.WriteLine("[" + string.Join(", ", i.ToArray()) + "]");
            }           

        }

        //Runtime: 644 ms
        //Memory Usage: 38.3 MB
        public static IList<IList<string>> GroupAnagramsOld(string[] strs)
        {
            if (strs.Length == 0)
                return new List<IList<string>>();

            Dictionary<string, IList<string>> dic = new Dictionary<string, IList<string>>();

            for (int i = 0; i < strs.Length; i++)
            {
                char[] a = strs[i].ToCharArray();
                Array.Sort(a);

                string key = new string(a);


                if (dic.ContainsKey(key))
                {
                    dic[key].Add(strs[i]);
                }
                else
                {
                    List<string> temp = new List<string>();
                    temp.Add(strs[i]);
                    dic.Add(key, temp);
                }
            }

            return dic.Values.ToList();
        }

        //Runtime: 276 ms
        //Memory Usage: 38.2 MB
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var result = new List<IList<string>>();

            if (strs.Length == 0)
                return result;

            Dictionary<string, IList<string>> dic = new Dictionary<string, IList<string>>();

            foreach (string s in strs)
            {
                char[] a = s.ToCharArray();
                Array.Sort(a);

                string key = new string(a);

                if (dic.ContainsKey(key))
                {
                    dic[key].Add(s);
                }
                else
                {
                    IList<string> temp = new List<string>
                    {
                        s
                    };
                    dic.Add(key, temp);
                }
            }

            foreach(var a in dic.Values)
            {
                result.Add(a);
            }

            return result;
        }        

    }
}
