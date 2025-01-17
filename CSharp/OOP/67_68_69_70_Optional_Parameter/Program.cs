using System.Runtime.Intrinsics.X86;
using System;
using System.Runtime.InteropServices;

namespace _67_68_69_70_Optional_Parameter
{
    internal class Program
    {

        //There are 4 ways that can be used to make method parameters optional.
        //1. Use parameter arrays
        //2. Method overloading
        //3. Specify parameter defaults
        //4. Use OptionalAttribute that is present in System.Runtime.InteropServices namespace
        //------------------------------------

        /// <summary>
        /// Part 1 Using parameter arrays, to make method parameters optional:
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <param name="restOfTheNumbers"></param>
        public static void AddNumbers(int firstNumber, int secondNumber, params object[] restOfTheNumbers)
        {
            int result = firstNumber + secondNumber;
            foreach (int i in restOfTheNumbers)
            {
                result += i;
            }

            Console.WriteLine("Total = " + result.ToString());
        }

        //this is wrong, optional must be at the end of parameter
        //public static void AddNumbers(int firstNumber, params object[] restOfTheNumbers, int secondNumber)
        //{
        //   //your logic
        //}


        /// <summary>
        /// Part 2 Making method parameters optional using method overloading
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        public static void AddNumbersV2(int firstNumber, int secondNumber)
        {
            AddNumbersV2(firstNumber, secondNumber, null);
        }

        public static void AddNumbersV2(int firstNumber, int secondNumber, int[] restOfNumbers)
        {
            int result = firstNumber + secondNumber;
            if (restOfNumbers != null)
            {
                foreach (int i in restOfNumbers)
                {
                    result += i;
                }
            }

            Console.WriteLine("Sum = " + result);
        }

        /// <summary>
        /// Part 3 Making method parameters optional by specifying parameter defaults
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <param name="restOfTheNumbers"></param>
        public static void AddNumbersV3(int firstNumber, int secondNumber, int[] restOfTheNumbers = null)
        {
            int result = firstNumber + secondNumber;

            // loop thru restOfTheNumbers only if it is not null
            // otherwise you will get a null reference exception
            if (restOfTheNumbers != null)
            {
                foreach (int i in restOfTheNumbers)
                {
                    result += i;
                }
            }
            Console.WriteLine("Total = " + result.ToString());
        }

        public static void Test(int a, int b = 10, int c = 20)
        {
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("c = " + c);
        }

        /// <summary>
        /// Part 4 Making method parameters optional by using OptionalAttribute
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <param name="restOfTheNumbers"></param>
        public static void AddNumbersV4(int firstNumber, int secondNumber, [Optional] int[] restOfTheNumbers)
        {
            int result = firstNumber + secondNumber;

            // loop thru restOfTheNumbers only if it is not null
            // otherwise you will get a null reference exception
            if (restOfTheNumbers != null)
            {
                foreach (int i in restOfTheNumbers)
                {
                    result += i;
                }
            }

            Console.WriteLine("Total = " + result.ToString());
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Part 1");
            AddNumbers(1, 2);
            AddNumbers(1, 2, 3);

            Console.WriteLine();
            Console.WriteLine("Part 2");
            AddNumbersV2(1, 2);
            AddNumbersV2(1, 2, new int[] { 30, 40, 50 });

            Console.WriteLine();
            Console.WriteLine("Part 3");
            AddNumbersV3(1, 2);
            AddNumbersV3(1, 2, new int[] { 1, 2, 3 });

            Console.WriteLine();
            //even if we put also can because already have default
            Test(1);

            Console.WriteLine();
            Test(1, 2, 3);

            Console.WriteLine();
            //we can select to put in c
            Test(1, c: 5);

            Console.WriteLine();
            Console.WriteLine("Part 4 [Optional]");
            AddNumbersV4(1, 2);
            AddNumbersV4(1, 2, new int[] { 1, 2, 3 });
        }
    }
}
