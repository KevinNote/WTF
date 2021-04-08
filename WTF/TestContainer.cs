using System.Collections.Generic;
using WTF.Interfaces;

namespace WTF
{
    public class TestContainer
    {
        private Queue<ITest> _queue;

        public TestContainer()
        {
            _queue = new Queue<ITest>();
        }

        public TestContainer AddTest(ITest t)
        {
            _queue.Enqueue(t);
            return this;
        }

        public TestContainer Clear()
        {
            _queue.Clear();
            return this;
        }

        public TestContainer DoTest()
        {
            while (_queue.Count != 0)
            {
                var t = _queue.Dequeue();
                t.Test();
            }
            return this;
        }
    }
}