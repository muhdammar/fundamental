namespace _89_ParameterizedThreadStart_delegate
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter the target number");
            object target = Console.ReadLine();

            // Create an instance ParameterizedThreadStart delegate
            ParameterizedThreadStart parameterizedThreadStart =
                new ParameterizedThreadStart(Number.PrintNumbers);
            Thread T1 = new Thread(parameterizedThreadStart);
            // Pass the target number to the start function, which
            // will then be passed automatically to PrintNumbers() function

            //alternative to above code, please uncomment to run
            //Thread T1 = new Thread(Number.PrintNumbers);
            T1.Start(target);
        }
    }

    class Number
    {
        public static void PrintNumbers(object target)
        {
            int number = 0;
            if (int.TryParse(target.ToString(), out number))
            {
                for (int i = 1; i <= number; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
