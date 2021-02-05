namespace WTF
{
    public class StringPlus
    {
        public static void TraditionalAdd(int loop = 5000)
        {
            long l = 0;
            for (int i = 0; i < 5000; ++i)
            {
                l = l + i;
            }
        }
        public static void FrontAdd(int loop = 5000)
        {
            long l = 0;
            for (int i = 0; i < 5000; ++i)
            {
                l += i;
            }
        }
        
    }
}