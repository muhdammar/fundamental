using System.Xml.Linq;

namespace _15_Delegate_Usages_Examples
{
    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Experience { get; set; }

        public static void PromoteEmployee(List<Employee> employeeList, IsPromotable IsEligibleToPromote) 
        {
            foreach (Employee employee in employeeList)
            {
                //this one not flexible/reusable logic
                //if (employee.Experience >= 5) { 
                //    Console.WriteLine(employee.Name + " promoted");
                //}

                //this make our class more reusable instead of hardcode the code
                if (IsEligibleToPromote(employee))
                {
                    Console.WriteLine(employee.Name + " promoted");
                }
            }
        }
    }

    delegate bool IsPromotable(Employee employee);

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee() { ID = 1, Name = "Ammar", Salary = 100, Experience = 6 });
            employees.Add(new Employee() { ID = 2, Name = "Abu", Salary = 100, Experience = 4 });
            employees.Add(new Employee() { ID = 2, Name = "Ali", Salary = 100, Experience = 7 });
            employees.Add(new Employee() { ID = 2, Name = "Azizi", Salary = 100, Experience = 3 });

            //delegate example using simple function syntax
            IsPromotable isPromotable = new IsPromotable(Promote);
            Employee.PromoteEmployee(employees, isPromotable);

            //using lambda function
            Employee.PromoteEmployee(employees, emp => emp.Experience >= 5);
        }

        //1# use simple function syntax
        public static bool Promote(Employee employee)
        {
            if (employee.Experience >= 5)
            {
                return true;
            }
            return false;
        }
    }
}
