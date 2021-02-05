using System;
using System.Collections;

namespace WTF
{
    public class Iter : ITest
    {
        private static long GetArrayWithIteratorTime(int length)
        {
            long count = 0;
            int[] i = new int[length];
            return Basic.GetTime(() =>
            {
                foreach (int m in i)
                {
                    count += m;
                }
            });
        }
        
        private static long GetArrayWithoutIteratorTime(int length)
        {
            long count = 0;
            int[] i = new int[length];
            return Basic.GetTime(() =>
            {
                for (int l = 0; l < length; ++l)
                {
                    count += i[l];
                }
            });
        }
        
        private static long GetArrayListWithoutIteratorTime(int length)
        {
            long count = 0;
            ArrayList al = new ArrayList();
            for (int l = 0; l < length; ++l)
            {
                al.Add(1);
            }
            return Basic.GetTime(() =>
            {
                for (int l = 0; l < al.Count; ++l)
                {
                    count += (int)al[l];
                }
            });
        }
        
        private static long GetArrayListWithIteratorTime(int length)
        {
            long count = 0;
            ArrayList al = new ArrayList();
            for (int l = 0; l < length; ++l)
            {
                al.Add(1);
            }
            return Basic.GetTime(() =>
            {
                foreach (int l in al)
                {
                    count += l;
                }
            });
        }
        
        public void Test(int loop = 100000)
        {
            Console.WriteLine($"┌-------------------------------┐");
            Console.WriteLine($"|             Array             |");
            Console.WriteLine($"├-------------------------------┤");
            Console.WriteLine($"| Name\t\t| Time\t\t|");
            Console.WriteLine($"| No\t\t| {Basic.GetTime(() => { GetArrayWithoutIteratorTime(loop); }, 1000)}\t|");
            Console.WriteLine($"| Yes\t\t| {Basic.GetTime(() => { GetArrayWithIteratorTime(loop); }, 1000)}\t|");
            Console.WriteLine($"├-------------------------------┤");
            Console.WriteLine($"|           ArrayList           |");
            Console.WriteLine($"├-------------------------------┤");
            Console.WriteLine($"| Name\t\t| Time\t\t|");
            Console.WriteLine($"| No\t\t| {Basic.GetTime(() => { GetArrayListWithoutIteratorTime(loop); }, 5)}\t\t|");
            Console.WriteLine($"| Yes\t\t| {Basic.GetTime(() => { GetArrayListWithIteratorTime(loop); },5)}\t\t|");
            Console.WriteLine($"└-------------------------------┘");
        }
    }
}