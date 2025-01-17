using System;
using System.Collections.Generic;
 
namespace INSCALE_DEC_2024_TECHNICAL_TEST
{
    /*Task: Create a simplified employee management system using object-oriented programming in C#.
 
	Requirements:
 
	Create a base class called "Employee" as follow:
	========================================================================
	| Employee                                                     		   |
	-----------------------------------------------------------------------|
	| Properties                                                           |
	| Id : int                                                    		   |
	| Name : string                                                        |
	| BaseSalary: decimal                                                  |
	-----------------------------------------------------------------------|
	| Methods                                                              |
	| decimal GetSalary()                                                  |
	========================================================================
 
	The GetSalary() method returns a decimal representing the employee's salary. In the base class, the GetSalary() method should return the BaseSalary.
	Implement two derived classes that inherit from the Employee class:
	- Manager   : This class should have an additional property called "Allowance" (decimal), which represents the manager's allowance in addition to their salary. 
				  Override the GetSalary() method to calculate and return the total salary including the allowance.
	- Developer : This class should have an additional property called "HourlyRate" (decimal), which represents the developer's hourly rate. 
				  Override the GetSalary() method to calculate and return the salary based on the number of hours worked. 
				  Assume that a developer works a fixed number of hours per month. (E.g. 160 hours/month)
	In the Program class, create one instance of the Manager derived class and 3 instances of the Developer derived class
	- Set the properties for each employee (id, name, and any additional properties).
	- Print the employee details (id, name, and salary).
	Assessment:
	Provide a brief explanation of the design decisions you made during the implementation and how the concepts of inheritance and polymorphism were applied.*/
    public class Program
    {
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal BaseSalary { get; set; }
            public virtual decimal GetSalary()
            {
                return BaseSalary;
            }
            public override string ToString()
            {
               return $"Name: {Name}, Id: {Id}, Salary: {GetSalary()}";
            }
        }
        public class Manager : Employee
        {
            public decimal Allowance { get; set; }
            public Manager(int Id, string Name, decimal BaseSalary, decimal Allowance) //can be improve by using base()
            {
                this.Id = Id;
                this.Name = Name;
                this.BaseSalary = BaseSalary;
                this.Allowance = Allowance;
            }
            public override decimal GetSalary()
            {
                return BaseSalary + Allowance;
            }
        }
        public class Developer : Employee
        {
            public decimal HourlyRate { get; set; }
            public Developer(int Id, string Name, decimal BaseSalary, decimal HourlyRate)
            {
                this.Id = Id;
                this.Name = Name;
                this.BaseSalary = BaseSalary;
                this.HourlyRate = HourlyRate;
            }
            public override decimal GetSalary()
            {
                return BaseSalary + (HourlyRate * 160);
            }

        }

        public static void Main()
        {
            List<Employee> employees = new List<Employee>();
            Manager manager = new Manager(1, "Ammar", 1000, 1000);//2000
            Developer emp1 = new Developer(2, "Ammar2", 1000, 10);//2600
            Developer emp2 = new Developer(2, "Ammar3", 2000, 10);//3600
            Developer emp3 = new Developer(2, "Ammar4", 3000, 10);//4600
            employees.Add(manager);
            employees.Add(emp1);
            employees.Add(emp2);
            employees.Add(emp3);
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee.ToString());
            }
        }
    }
}