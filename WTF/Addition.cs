using System;

namespace WTF
{
    public class Addition : ITest
    {
        private static void TraditionalAdd(int loop = 5000)
        {
            long l = 0;
            for (int i = 0; i < 5000; ++i)
            {
                l = l + i;
            }
        }

        private static void FrontAdd(int loop = 5000)
        {
            long l = 0;
            for (int i = 0; i < 5000; ++i)
            {
                l += i;
            }
        }

        private static void StrTraditionalAdd(int loop = 5000)
        {
            string l = "";
            for (int i = 0; i < 5000; ++i)
            {
                l = l + i;
            }
        }

        private static void StrFrontAdd(int loop = 5000)
        {
            string l = "";
            for (int i = 0; i < 5000; ++i)
            {
                l += i;
            }
        }
        
        public void Test(int loop = 50000)
        {
            Console.WriteLine($"┌-------------------------------┐");
            Console.WriteLine($"|\tNumber x1000\t\t|");
            Console.WriteLine($"├-------------------------------┤");
            Console.WriteLine($"| Name\t\t| Time\t\t|");
            Console.WriteLine($"| =+\t\t| {Basic.GetTime(() => { TraditionalAdd(loop); }, 1000)}\t\t|");
            Console.WriteLine($"| +=\t\t| {Basic.GetTime(() => { FrontAdd(loop); }, 1000)}\t\t|");
            Console.WriteLine($"├-------------------------------┤");
            Console.WriteLine($"|\tString x5\t\t|");
            Console.WriteLine($"├-------------------------------┤");
            Console.WriteLine($"| Name\t\t| Time\t\t|");
            Console.WriteLine($"| =+\t\t| {Basic.GetTime(() => { StrTraditionalAdd(loop); }, 5)}\t|");
            Console.WriteLine($"| +=\t\t| {Basic.GetTime(() => { StrFrontAdd(loop); },5)}\t|");
            Console.WriteLine($"└-------------------------------┘");
        }
    }
}