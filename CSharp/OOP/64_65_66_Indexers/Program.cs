
namespace _64_65_66_Indexers
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
    }

    public class Company
    {
        private List<Employee> listEmployees;

        public Company()
        {
            listEmployees = new List<Employee>();
            listEmployees.Add(new Employee { EmployeeId = 1, Name = "Mike", Gender = "Male" });
            listEmployees.Add(new Employee { EmployeeId = 2, Name = "Pam", Gender = "Female" });
            listEmployees.Add(new Employee { EmployeeId = 3, Name = "John", Gender = "Male" });
            listEmployees.Add(new Employee { EmployeeId = 4, Name = "Maxine", Gender = "Female" });
            listEmployees.Add(new Employee { EmployeeId = 5, Name = "Emiliy", Gender = "Female" });
            listEmployees.Add(new Employee { EmployeeId = 6, Name = "Scott", Gender = "Male" });
            listEmployees.Add(new Employee { EmployeeId = 7, Name = "Todd", Gender = "Male" });
            listEmployees.Add(new Employee { EmployeeId = 8, Name = "Ben", Gender = "Male" });
        }

        public string this[int employeeId]
        {
            get
            {
                return listEmployees.FirstOrDefault(x => x.EmployeeId == employeeId)?.Name;
            }
            set
            {
                var employee = listEmployees.FirstOrDefault(x => x.EmployeeId == employeeId);
                if (employee != null)
                {
                    employee.Name = value;
                }
            }
        }

        // Helper method to display all employees
        public void DisplayAllEmployees()
        {
            Console.WriteLine("\nAll Employees:");
            foreach (var emp in listEmployees)
            {
                Console.WriteLine($"ID: {emp.EmployeeId}, Name: {emp.Name}, Gender: {emp.Gender}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee Management System");
            Console.WriteLine("-------------------------");

            // Create instance of Company
            var company = new Company();

            // Display initial employee list
            company.DisplayAllEmployees();

            // Using indexer to get employee name
            Console.WriteLine("\nDemonstrating Indexer Get:");
            Console.WriteLine($"Employee with ID 1: {company[1]}");
            Console.WriteLine($"Employee with ID 4: {company[4]}");
            Console.WriteLine($"Employee with ID 8: {company[8]}");

            // Using indexer to update employee names
            Console.WriteLine("\nDemonstrating Indexer Set:");
            company[2] = "Pamela"; // Update Pam to Pamela
            company[5] = "Emily";  // Fix spelling of Emiliy

            // Display updated employee list
            company.DisplayAllEmployees();

            // Demonstrate handling non-existent employee
            Console.WriteLine("\nTrying to access non-existent employee:");
            Console.WriteLine($"Employee with ID 10: {company[10]}"); // Will return null

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}