namespace WTF.Interfaces
{
    public interface ITest
    {
        public abstract void Test(int loop = 5000);

        public abstract string GetTestName();
    }
}