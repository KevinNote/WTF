namespace WTF
{
    class Program
    {
        static void Main(string[] args)
        {
            ITest p;
            p = new Addition();
            p.Test();
            p = new Iter();
            p.Test();
            p = new TwoDArray();
            p.Test();
            p = new RefOrNot();
            p.Test();
        }
    }
}