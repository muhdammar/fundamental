using System.Threading;

namespace _93_Protecting_shared_resources_from_concurrent_access_in_multithreading
{
    internal class Program
    {
        static int Total = 0;
        static int ThreadTotal = 0;
        public static void Main()
        {
            //without thread example
            AddOneMillion();
            AddOneMillion();
            AddOneMillion();
            Console.WriteLine("Example Without Thread Total = " + Total); //will show 30k

            //with thread example
            Thread thread1 = new Thread(Program.AddOneMillionThread);
            Thread thread2 = new Thread(Program.AddOneMillionThread);
            Thread thread3 = new Thread(Program.AddOneMillionThread);

            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            Console.WriteLine("Example Thread Total = " + ThreadTotal);//the result will not sum to 30k because
                                                                       //of thread issue (not thread safe)

            //reset
            ThreadTotal = 0;

            Thread thread4 = new Thread(Program.AddOneMillionThreadSafe);
            Thread thread5 = new Thread(Program.AddOneMillionThreadSafe);
            Thread thread6 = new Thread(Program.AddOneMillionThreadSafe);

            thread4.Start();
            thread5.Start();
            thread6.Start();

            thread4.Join();
            thread5.Join();
            thread6.Join();

            Console.WriteLine("Example Thread safe Total = " + ThreadTotal);
        }

        public static void AddOneMillionThread()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                ThreadTotal++;
            }

        }
        static object _lock = new object();

        public static void AddOneMillionThreadSafe()
        {
            //with interlocking method
            //uncomment this to know the result
            //for (int i = 1; i <= 1000000; i++)
            //{
            //    Interlocked.Increment(ref ThreadTotal);
            //}

            //with locking
            for (int i = 1; i <= 1000000; i++)
            {
                lock (_lock)
                {
                    ThreadTotal++;
                }
            }
        }

        public static void AddOneMillion()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                Total++;
            }
        }
    }
}
