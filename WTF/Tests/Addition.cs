using System;
using WTF.Interfaces;

namespace WTF.Tests
{
    public class Addition : ITest
    {
        private static void TraditionalAdd(int loop = 5000)
        {
            long l = 0;
            for (int i = 0; i < loop; ++i)
            {
                l = l + i;
            }
        }

        private static void FrontAdd(int loop = 5000)
        {
            long l = 0;
            for (int i = 0; i < loop; ++i)
            {
                l += i;
            }
        }

        private static void StrTraditionalAdd(int loop = 5000)
        {
            string l = "";
            for (int i = 0; i < loop; ++i)
            {
                l = l + i;
            }
        }

        private static void StrFrontAdd(int loop = 5000)
        {
            string l = "";
            for (int i = 0; i < loop; ++i)
            {
                l += i;
            }
        }
        
        public void Test(int loop = 50000)
        {
            Console.WriteLine($"[Number x1000]");
            Console.WriteLine($"=+ : {Basic.GetTime(() => { TraditionalAdd(loop); }, 1000)}");
            Console.WriteLine($"+= : {Basic.GetTime(() => { FrontAdd(loop); }, 1000)}");
            Console.WriteLine($"[String x5]");
            Console.WriteLine($"=+ : {Basic.GetTime(() => { StrTraditionalAdd(loop); }, 5)}");
            Console.WriteLine($"+= : {Basic.GetTime(() => { StrFrontAdd(loop); },5)}");
        }

        public string GetTestName()
        {
            return "+= & =+ Loss Test";
        }
    }
}