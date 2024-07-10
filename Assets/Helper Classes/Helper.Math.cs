namespace SG.Utils
{
    public static partial class Helper
    {
        public static class Math
        {
            public static int Fibonacci(int n)
            {
                return (n < 2) ? n : Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }
    }
}