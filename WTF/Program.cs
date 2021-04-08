using WTF.Tests;

namespace WTF
{
    class Program
    {
        static void Main(string[] args)
        {
            TestContainer container = new TestContainer();
            container
                .Clear()
                .AddTest(new Addition())
                .AddTest(new Iter())
                .AddTest(new TwoDArray())
                .AddTest(new RefOrNot())
                .DoTest();
        }
    }
}