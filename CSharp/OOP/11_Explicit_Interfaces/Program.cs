namespace _11_Explicit_Interfaces
{
    interface I1
    {
        void Print();
    }

    interface I2
    {
        void Print();
    }

    interface I3
    {
        void Print();
    }

    interface I4
    {
        void Print();
    }

    internal class Program : I1, I2, I3, I4
    {
        /// <summary>
        /// will use as default implementation
        /// </summary>
        public void Print()
        {
            Console.WriteLine("Default Interface Print method called");
        }

        /// <summary>
        /// this is how we can call same method to different interface (explicit interfaces)
        /// CANNOT HAVE ACCESS MODIFIER
        /// </summary>
        void I2.Print() 
        {
            Console.WriteLine("I2 Print method called");
        }

        void I4.Print()
        {
            Console.WriteLine("I4 Print method called");
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Print();//output: Default Interface Print method called

            ((I1)program).Print();//output: Default Interface Print method called

            //we can access thru explicit via type casting only
            ((I2)program).Print();//output: I2 Print method called

            //if not I3 explicit inside the class, it will use default print method
            ((I3)program).Print();//output: Default Interface Print method called

            ((I4)program).Print();//output: I4 Print method called

            //ANOTHER WAY can use reference object like below
            I2 i2 = new Program();
            i2.Print();
        }
    }
}
