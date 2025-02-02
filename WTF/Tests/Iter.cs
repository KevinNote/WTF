﻿using System;
using System.Collections;
using System.Collections.Generic;
using WTF.Interfaces;

namespace WTF.Tests
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
                    count += (int) al[l];
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

        private static long GetListWithoutIteratorTime(int length)
        {
            long count = 0;
            List<int> al = new List<int>();
            for (int l = 0; l < length; ++l)
            {
                al.Add(1);
            }

            return Basic.GetTime(() =>
            {
                for (int l = 0; l < al.Count; ++l)
                {
                    count += (int) al[l];
                }
            });
        }

        private static long GetListWithIteratorTime(int length)
        {
            long count = 0;
            List<int> al = new List<int>();
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
            Console.WriteLine("[ARRAY]");
            Console.WriteLine($"No Iter : {Basic.GetTime(() => { GetArrayWithoutIteratorTime(loop); }, 1000)}");
            Console.WriteLine($"Has Iter: {Basic.GetTime(() => { GetArrayWithIteratorTime(loop); }, 1000)}");
            Console.WriteLine("[ARRAY LIST]");
            Console.WriteLine($"No Iter : {Basic.GetTime(() => { GetArrayListWithoutIteratorTime(loop); }, 5)}");
            Console.WriteLine($"Has Iter: {Basic.GetTime(() => { GetArrayListWithIteratorTime(loop); }, 5)}");
            Console.WriteLine("[LIST]");
            Console.WriteLine($"No Iter : {Basic.GetTime(() => { GetListWithoutIteratorTime(loop); }, 5)}");
            Console.WriteLine($"Has Iter: {Basic.GetTime(() => { GetListWithIteratorTime(loop); }, 5)}");
        }

        public string GetTestName()
        {
            return "Iterator Loss Test";
        }
    }
}