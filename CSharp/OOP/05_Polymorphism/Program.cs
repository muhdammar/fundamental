namespace _05_Polymorphism
{
    internal class Program
    {
        public class Employee
        {
            public string FirstName = "FN";
            public string LastName = "LN";

            //put virtual as for derived class to override this method,
            //lets see if remove virtual, still override?
            //dah try, if remove virtual, we cannt override (syntax error)
            public virtual void PrintFullName()
            {
                Console.WriteLine(FirstName + " " + LastName);
            }
        }
        public class FullTimeEmployee : Employee
        {
            //public void PrintFullName()
            //{
            //    Console.WriteLine(FirstName + " " + LastName + "- Full time");
            //}
            public override void PrintFullName()
            {
                Console.WriteLine(FirstName + " " + LastName + "- Full time");
            }
        }
        public class PartTimeEmployee : Employee
        {
            public override void PrintFullName()
            {
                Console.WriteLine(FirstName + " " + LastName + "- Part time");
            }
        }
        public class TemporaryEmployee : Employee
        {
            //If we comment this, it will use base class method

            //public override void PrintFullName()
            //{
            //    Console.WriteLine(FirstName + " " + LastName + "- Temporary  time");
            //}
        }

        static void Main(string[] args)
        {
            Employee[] employees = new Employee[4];
            
            employees[0] = new Employee();
            employees[1] = new PartTimeEmployee();
            employees[2] = new FullTimeEmployee();
            employees[3] = new TemporaryEmployee();

            foreach (Employee e in employees)
            {
                e.PrintFullName();
            }

            //polimorphism is basically enable us invoke derived class method through Base Class reference variable at runtime, thats it!!
        }
    }
}
