namespace _91_Thread_function_using_callback_method
{
    // Step 1: Create a callback delegate. The actual callback method
    // signature should match with the signature of this delegate.

    public delegate void SumOfNumbersCallback(int sumOfNumbers);

    // Step 2: Create Number class to compute the sum of numbers and
    // to call the callback method
    class Number
    {
        // The traget number this class needs to compute the sum of numbers
        int _target;

        // Delegate to call when the the Thread function completes                 
        // computing the sum of numbers
        SumOfNumbersCallback _callbackMethod;

        // Constructor to initialize the target number and the callback delegateinitialize
        public Number(int target, SumOfNumbersCallback callbackMethod)
        {
            this._target = target;
            this._callbackMethod = callbackMethod;
        }

        // This thread function computes the sum of numbers and then invokes
        // the callback method passing it the sum of numbers
        public void ComputeSumOfNumbers()
        {
            int sum = 0;
            for (int i = 1; i <= _target; i++)
            {
                sum = sum + i;
            }

            if (_callbackMethod != null)
            {
                _callbackMethod(sum);
            }
        }
    }

    // Step 3: This class consumes the Number class created in Step 2
    class Program
    {
        // Callback method that will receive the sum of numbers
        public static void PrintSumOfNumbers(int sum)
        {
            Console.WriteLine("Sum of numbers is " + sum);
        }

        //my own testing (ammar)
        public static void PrintSumOfNumbersV2(int sum)
        {
            Console.WriteLine("Sum of numbers bla bla bla " + sum);
        }
        public static void Main()
        {
            // Prompt the user for the target number
            Console.WriteLine("Please enter the target number");
            // Read from the console and store it in target variable
            int target = Convert.ToInt32(Console.ReadLine());

            // Create an instance of callback delegate and to it's constructor
            // pass the name of the callback function (PrintSumOfNumbers)

            SumOfNumbersCallback callbackMethod = new SumOfNumbersCallback(PrintSumOfNumbers);

            // Create an instance of Number class and to it's constrcutor pass the target
            // number and the instance of callback delegate
            Number number = new Number(target, callbackMethod);

            // Create an instance of Thread class and specify the Thread function to invoke
            Thread T1 = new Thread(new ThreadStart(number.ComputeSumOfNumbers));
            T1.Start();

            //my own testing (ammar)
            callbackMethod = new SumOfNumbersCallback(PrintSumOfNumbersV2);
            number = new Number(target, callbackMethod);
            Thread T2 = new Thread(new ThreadStart(number.ComputeSumOfNumbers));
            T2.Start();
        }
    }
}
