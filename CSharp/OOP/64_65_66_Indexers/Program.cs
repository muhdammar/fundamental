
namespace _64_65_66_Indexers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace Demo
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

            // Indexer for accessing by employee ID
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

            // Indexer for accessing by gender
            public string this[string gender]
            {
                get
                {
                    return listEmployees.Count(x => x.Gender == gender).ToString();
                }
                set
                {
                    foreach (Employee employee in listEmployees)
                    {
                        if (employee.Gender == gender)
                        {
                            employee.Gender = value;
                        }
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

                // Using ID indexer to get employee names
                Console.WriteLine("\nDemonstrating ID Indexer Get:");
                Console.WriteLine($"Employee with ID 1: {company[1]}");
                Console.WriteLine($"Employee with ID 4: {company[4]}");

                // Using gender indexer to count employees
                Console.WriteLine("\nDemonstrating Gender Indexer Get:");
                Console.WriteLine($"Number of Male employees: {company["Male"]}");
                Console.WriteLine($"Number of Female employees: {company["Female"]}");

                // Using ID indexer to update names
                Console.WriteLine("\nDemonstrating ID Indexer Set:");
                company[2] = "Pamela"; // Update Pam to Pamela

                // Using gender indexer to update gender
                Console.WriteLine("\nDemonstrating Gender Indexer Set:");
                company["Male"] = "M"; // Update all Male to M
                company["Female"] = "F"; // Update all Female to F

                // Display updated employee list
                Console.WriteLine("\nEmployee list after updates:");
                company.DisplayAllEmployees();

                // Show updated gender counts
                Console.WriteLine("\nUpdated gender counts:");
                Console.WriteLine($"Number of M employees: {company["M"]}");
                Console.WriteLine($"Number of F employees: {company["F"]}");

                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
        }
    }
}