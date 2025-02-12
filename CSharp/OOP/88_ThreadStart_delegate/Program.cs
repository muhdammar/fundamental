namespace _88_ThreadStart_delegate
{
    class Program
    {
        public static void Main()
        {
            Thread T1 = new Thread(Number.PrintNumbers);
            Thread T2 = new Thread(new ThreadStart(Number.PrintNumbers));
            Thread T3 = new Thread(delegate () { Number.PrintNumbers(); });
            Thread T4 = new Thread(() => Number.PrintNumbers());

            Number number = new Number();
            Thread T5 = new Thread(number.PrintNumbersV2);
            T1.Start();
        }
    }

    class Number
    {
        public static void PrintNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
        }

        public void PrintNumbersV2()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
