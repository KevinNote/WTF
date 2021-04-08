using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WTF
{
    public class Basic
    {
        public static long GetTime(Action a, int loopTimes = 1)
        {
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < loopTimes; ++i)
            {
                a.Invoke();
            }

            sw.Stop();
            return sw.Elapsed.Ticks;
        }

        public static MemSize GetMemory(Action a, int loopTimes = 1)
        {
            List<long> mem = new List<long>();
            for (int i = 0; i < loopTimes; ++i)
            {
                long start = GC.GetTotalMemory(true);
                a.Invoke();
                GC.Collect();
                GC.WaitForFullGCComplete();
                long end = GC.GetTotalMemory(true);
                mem.Add(end - start);
            }

            double avg = 0;
            mem.ForEach(x => avg += 1.0 * x / 12);
            return new MemSize(Convert.ToInt64(avg));

        }

        public class MemSize
        {
            public MemSize()
            { }

            public MemSize(long b)
                => size = b;
            
            private long size = 0;

            public void FromByte(long num)
                => size = num;

            public void FromKByte(long num)
                => size = num * 1024;

            public void FromMByte(long num)
                => size = num * 1024 * 1024;

            public void FromGByte(long num)
                => size = num * 1024 * 1024 * 1024;

            public long ToByte()
                => size;

            public long ToKByte()
                => size / 1024;

            public long ToMByte()
                => size / 1024 / 1024;

            public long ToGByte()
                => size / 1024 / 1024 / 1024;

            public override string ToString()
            {
                return ToByte() + " Byte";
            }
        }
    }
}