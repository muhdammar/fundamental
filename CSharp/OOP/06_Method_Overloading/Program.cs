namespace _06_Method_Overloading
{
    public class Calculator
    {
        // Method to add two integers
        public int Add(int a, int b)
        {
            return a + b;
        }

        // Overloaded method to add three integers
        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        // Overloaded method to add two doubles
        public double Add(double a, double b)
        {
            return a + b;
        }

        // SYNTAX ERROR - BECAUSE SAME PARAMETER EVEN DIFFERENT RETURN TYPE
        //COMMENT THIS TO REMOVE THE ERROR
        //public float Add(double a, double b)
        //{
        //    return (float)a + (float)b;
        //}

        // SYNTAX ERROR - BECAUSE SAME PARAMETER
        public double Add(double a, params double b) //This "params"
        {
            return a + b;
        }
    }

    internal class Program
    {
        static void Main()
        {
            Calculator calculator = new Calculator();

            // Calls the method with two integer parameters
            Console.WriteLine("Add(5, 10) = " + calculator.Add(5, 10));

            // Calls the overloaded method with three integer parameters
            Console.WriteLine("Add(5, 10, 15) = " + calculator.Add(5, 10, 15));

            // Calls the overloaded method with two double parameters
            Console.WriteLine("Add(5.5, 10.5) = " + calculator.Add(5.5, 10.5));
        }
    }
}
