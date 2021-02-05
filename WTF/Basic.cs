using System;
using System.Diagnostics;

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
    }
}