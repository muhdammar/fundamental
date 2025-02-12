namespace _98_Anonymous_methods
{
    class Program
    {
        public static void Main()
        {
            List<Employee> listEmployees = new List<Employee>()
        {
            new Employee{ ID = 101, Name = "Mark"},
            new Employee{ ID = 102, Name = "John"},
            new Employee{ ID = 103, Name = "Mary"},
        };

            // Step 2: Create an instance of Predicate<Employee>
            // delegate and pass the method name as an argument
            // to the delegate constructor
            Predicate<Employee> predicateEmployee =
                new Predicate<Employee>(FindEmployee);

            // Step 3: Now pass the delegate instance as
            // the argument for Find() method
            Employee employee =
                listEmployees.Find(x => predicateEmployee(x));
            Console.WriteLine("ID = {0}, Name {1}",
                employee.ID, employee.Name);

            // Anonymous method is being passed as an argument to
            // the Find() method. This anonymous method replaces
            // the need for Step 1, 2 and 3
            employee = listEmployees.Find(delegate (Employee x){ return x.ID == 102; });
            Console.WriteLine("ID = {0}, Name {1}",
                employee.ID, employee.Name);
        }

        // Step 1: Create a method whose signature matches
        // with the signature of Predicate<Employee> delegate
        private static bool FindEmployee(Employee Emp)
        {
            return Emp.ID == 102;
        }

        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    }

}
