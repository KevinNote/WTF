using System;
using WTF.Interfaces;

namespace WTF.Tests
{
    public class TwoDArray : ITest
    {
        private static int[][] InitualizeArray(int loop)
        {
            int[][] array = new int[loop][];
            for (int i = 0; i < loop; ++i)
            {
                array[i] = new int[loop];
            }
            return array;
        }

        private static long Normal(int loop = 5000)
        {
            var array = InitualizeArray(loop);
            long count = 0;
            return Basic.GetTime(() =>
            {
                for (int i = 0; i < loop; ++i)
                {
                    for (int j = 0; j < loop; ++j)
                    {
                        count += array[i][j];
                    }
                }
            });
        }

        private static long Inverse(int loop = 5000)
        {
            var array = InitualizeArray(loop);
            long count = 0;
            return Basic.GetTime(() =>
            {
                for (int i = 0; i < loop; ++i)
                {
                    for (int j = 0; j < loop; ++j)
                    {
                        count += array[j][i];
                    }
                }
            });
        }

        public void Test(int loop = 5000)
        {
            Console.WriteLine("NORMAL: " + Normal(loop));
            Console.WriteLine("INVERSE: " + Inverse(loop));
        }

        public string GetTestName()
        {
            return "2D Array Index Order Loss Test";
        }
    }
}