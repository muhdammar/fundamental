namespace _78_Sort_a_list_of_complex_types
{
    internal class Program
    {
        /// <summary>
        /// use c# IComparable interface
        /// </summary>
        public class Customer : IComparable<Customer>
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Salary { get; set; }

            public int CompareTo(Customer obj)
            {
                //if (this.Salary > obj.Salary)
                //    return 1;
                //else if (this.Salary < obj.Salary)
                //    return -1;
                //else
                //    return 0;

                // OR, Alternatively you can also invoke CompareTo() method. 
                return this.Salary.CompareTo(obj.Salary);
            }
        }


        /// <summary>
        /// use c# IComparer interface
        /// </summary>
        public class SortByName : IComparer<Customer>
        {
            public int Compare(Customer x, Customer y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }


        static void Main(string[] args)
        {
            Customer customer1 = new Customer()
            {
                ID = 101,
                Name = "Mark",
                Salary = 4000
            };

            Customer customer2 = new Customer()
            {
                ID = 102,
                Name = "John",
                Salary = 7000
            };

            Customer customer3 = new Customer()
            {
                ID = 103,
                Name = "Ken",
                Salary = 5500
            };

            List<Customer> listCutomers = new List<Customer>();
            listCutomers.Add(customer1);
            listCutomers.Add(customer2);
            listCutomers.Add(customer3);

            Console.WriteLine("Customers before sorting");
            foreach (Customer customer in listCutomers)
            {
                Console.WriteLine(customer.Name + " - " + customer.Salary);
            }

            // Sort() method should sort customers by salary
            listCutomers.Sort();

            Console.WriteLine("Customers after sorting");
            foreach (Customer customer in listCutomers)
            {
                Console.WriteLine(customer.Name + " - " + customer.Salary);
            }

            // To sort customers by name instead of salary
            // SortByName sortByName = new SortByName(); --> from kudvenkat, i change to use interface follow SOLID principles
            IComparer<Customer> sortByName = new SortByName();
            listCutomers.Sort(sortByName);

            Console.WriteLine("Customers after sorting by Name");
            foreach (Customer customer in listCutomers)
            {
                Console.WriteLine(customer.Name + " - " + customer.Salary);
            }
        }
    }
}
