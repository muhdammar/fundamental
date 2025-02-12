namespace _94_Monitor_Vs_Lock
{
    internal class Program
    {
       
        static int Total = 0;
        static object _lock = new object();
        public static void AddOneMillion()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                bool lockTaken = false;
                // Acquires the exclusive lock
                Monitor.Enter(_lock, ref lockTaken);
                try
                {
                    Total++;
                }
                finally
                {
                    // Releases the exclusive lock
                    if (lockTaken)
                        Monitor.Exit(_lock);
                }
            }
        }

        public static void AddOneMillionV2()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                // Acquires the exclusive lock
                Monitor.Enter(_lock);
                try
                {
                    Total++;
                }
                finally
                {
                    // Releases the exclusive lock
                    Monitor.Exit(_lock);
                }
            }
        }

        public static void AddOneMillionV3()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                bool lockTaken = false;
                // Acquires the exclusive lock
                Monitor.Enter(_lock, ref lockTaken);
                try
                {
                    Total++;
                }
                finally
                {
                    // Releases the exclusive lock
                    if (lockTaken)
                        Monitor.Exit(_lock);
                }
            }
        }
        static void Main(string[] args)
        {
            AddOneMillion();
            Console.WriteLine("(Shortcut) Total = {0}", Total);

            Total = 0;
            AddOneMillionV2();
            Console.WriteLine("(Basic Monitor) Total Monitor.Enter = {0}", Total);

            Total = 0;
            AddOneMillionV3();
            Console.WriteLine("(Enhanced Monitor) Total Monitor.Enter = {0}", Total);
        }
    }
}
