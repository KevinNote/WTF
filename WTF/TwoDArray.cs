using System;

namespace WTF
{
    public class TwoDArray : ITest
    {
        public static long Normal(int loop = 5000)
        {
            int[][] array = new int[loop][];
            for (int i = 0; i < loop; ++i)
            {
                array[i] = new int[loop];
            }
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
        
        public static long Inverse(int loop = 5000)
        {
            int[][] array = new int[loop][];
            for (int i = 0; i < loop; ++i)
            {
                array[i] = new int[loop];
            }
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
    }
}