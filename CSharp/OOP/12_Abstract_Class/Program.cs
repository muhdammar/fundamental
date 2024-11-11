namespace _12_Abstract_Class
{
    /// <summary>
    /// 1. incomplete class hence abstract class cannot be instantiated
    /// 2. be as base class to other derived class 
    /// 3. cannot have sealed keyword because sealed means it cannot be inherit
    /// if we sealed it contradict with abstract (want it to be as base class (inherit))
    /// So, sealed cannot have abstract, abstract cannot have sealed beneath it.
    /// </summary>
    abstract class Customer {


        /// <summary>
        /// abstract keyword:
        /// 1. cannot have private
        /// 2. cannot have implementation/body
        /// </summary>
        public abstract void Print();

        /// <summary>
        /// must have body since not marked as abstract
        /// </summary>
        public void Display()
        {
            Console.WriteLine("called abstract Display() method");
        }
    }

    /// <summary>
    /// required to implement Customer method since this class is abstract, othwrwise error
    /// </summary>
    internal class Program : Customer
    {
        /// <summary>
        /// how to override/implement abstract class
        /// 1. need to use override keyword
        /// </summary>
        public override void Print()
        {
            Console.WriteLine("called Program Print() method");
        }

        /// <summary>
        /// cannot override if not marked Customer class as abstract
        /// uncomment to see the error
        /// </summary>
        //public override void Display()
        //{
        //    Console.WriteLine("called Program Display() method");
        //}

        static void Main(string[] args)
        {
            //WAY #1
            Program program = new Program();
            program.Print();
            program.Display();

            //WAY #2
            Customer c = new Program();
            c.Print();
            c.Display();
        }
    }

    /// <summary>
    /// not required to implement Customer method since this class is abstract
    /// </summary>
    internal abstract class Main : Customer
    {
    }
}
