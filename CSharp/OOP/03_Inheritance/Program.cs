namespace _03_Inheritance
{
    internal class Program
    {
        #region Example 1
        /// <summary>
        /// this is parent class that share common attributes
        /// Inheritance is for reusability and help to avoid error
        /// </summary>
        public class Employee
        {
            public string FirstName;
            public string LastName;

            public void PrintFullName()
            {
                Console.WriteLine(FirstName + " " + LastName);
            }
        }
        public class FullTimeEmployee : Employee
        {
            public int Yearlysal;
        }
        public class PartTimeEmployee : Employee
        {
            public float Hourlysal;
        }

        public class A : PartTimeEmployee
        {

        }
        #endregion
        public class ParentClass
        {
            public ParentClass()
            {
                Console.WriteLine("parent class constructor was called");
            }

            public ParentClass(string Message)
            {
                Console.WriteLine(Message);
            }
        }

        public class ChildClass : ParentClass { 
            //public ChildClass()
            //{
            //    Console.WriteLine("Child class constructor was called");
            //}

            /// <summary>
            /// base() syntax is for parent constructor, so since parent class accept string parameter, 
            /// then we can use like base("this_is_parameter_for_parent")
            /// </summary>
            public ChildClass() : base("Derived class controlling parent class")
            {
                Console.WriteLine("Child class constructor was called");
            }
        }
        #region Example 2

        #endregion
        static void Main(string[] args)
        {
            FullTimeEmployee ft = new FullTimeEmployee();
            ft.FirstName = "Full";
            ft.LastName = "Time";
            ft.PrintFullName();
            ft.Yearlysal = 800000;

            //derived class has specific field
            PartTimeEmployee pt = new PartTimeEmployee();
            pt.FirstName = "Part";
            pt.LastName = "Time";
            pt.PrintFullName();
            pt.Hourlysal = 99999;

            //c# suppport multiple derived class
            A a = new A();
            a.Hourlysal = 1111; //class A is derived from part time, and part time is derived from employee class


            //example 2
            //parent constructor will call first then child class
            ChildClass CC = new ChildClass();
        }
    }
}
