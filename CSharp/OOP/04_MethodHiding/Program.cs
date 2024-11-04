namespace _04_MethodHiding
{
    internal class Program
    {
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
            public new void PrintFullName() //put new if intentional to hide this base method
            {
                //Console.WriteLine(FirstName + " " + LastName +"- Fulltime");

                //WAY TO CALL PARENT METHOD
                //#1 call base to call parent method
                base.PrintFullName();
            }
        }
        public class PartTimeEmployee : Employee
        {
            public new void PrintFullName() //put new if intentional to hide this base method
            {
                Console.WriteLine(FirstName + " " + LastName + "- Contractor");
            }
        }

        static void Main(string[] args)
        {
            FullTimeEmployee ft = new FullTimeEmployee();
            ft.FirstName = "Full";
            ft.LastName = "Time";
            ft.PrintFullName(); //this will call child method

            PartTimeEmployee pt = new PartTimeEmployee();
            pt.FirstName = "Part";
            pt.LastName = "Time";
            pt.PrintFullName(); //this will call child method

            //#2 use casting to parent class
            ((Employee)pt).PrintFullName(); ; //this will call parent method

            Employee emp = new PartTimeEmployee();
            emp.FirstName = "Part";
            emp.LastName = "Time";

            //#3 use parent class
            ((Employee)pt).PrintFullName(); ; //this will call parent method
        }
    }
}
