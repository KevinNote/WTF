using System;
using System.Collections.Generic;
using WTF.Interfaces;

namespace WTF.Tests
{
    public class RefOrNot : ITest
    {
        private void DeliverWithRef(ref List<string> list)
        {
            long i = 0;
            foreach (var m in list)
            {
                ++i;
            }
        }
        
        private void DeliverWithoutRef(List<string> list)
        {
            long i = 0;
            foreach (var m in list)
            {
                ++i;
            }
        }

        private List<string> GenerateList(int count = 200)
        {
            List<string> l = new List<string>();
            for (int i = 0; i < count; ++i)
            {
                l.Add(Guid.NewGuid().ToString());
            }

            return l;
        }
        
        
        public void Test(int loop = 5000)
        {
            var l = GenerateList();
            // With Ref
            var memWithRef = Basic.GetMemory(() =>
            {
                DeliverWithRef(ref l);
            }, loop);
            var memWithoutRef = Basic.GetMemory(() =>
            {
                DeliverWithRef(ref l);
            }, loop);

            var timeWithRef = Basic.GetTime(() =>
            {
                DeliverWithRef(ref l);
            }, loop);
            
            var timeWithoutRef = Basic.GetTime(() =>
            {
                DeliverWithoutRef( l);
            }, loop);

            Console.WriteLine("Memory Usage");
            Console.WriteLine("With Ref: " + memWithRef);
            Console.WriteLine("Without Ref: " + memWithoutRef);
            
            Console.WriteLine("Time Usage");
            Console.WriteLine("With Ref: " + timeWithRef);
            Console.WriteLine("Without Ref: " + timeWithoutRef);

        }

        public string GetTestName()
        {
            return "ref or not?";
        }
    }
}