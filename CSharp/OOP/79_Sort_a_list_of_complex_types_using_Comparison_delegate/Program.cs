namespace _79_Sort_a_list_of_complex_types_using_Comparison_delegate
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
    }
    internal class Program
    {
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
                ID = 103,
                Name = "John",
                Salary = 7000
            };

            Customer customer3 = new Customer()
            {
                ID = 102,
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
                Console.WriteLine(customer.ID);
            }

            // Approach 1
            // Step 2: Create an instance of Comparison delegate
            //Comparison<Customer> customerComparer = 
            //    new Comparison<Customer>(CompareCustomers);

            // Step 3: Pass the delegate instance to the Sort method
            //listCutomers.Sort(customerComparer);

            // Approach 2: Using delegate keyword
            //listCutomers.Sort(delegate(Customer c1, Customer c2)
            //{
            //    return (c1.ID.CompareTo(c2.ID));
            //});

            // Aaproach 3: Using lambda expression
            listCutomers.Sort((x, y) => x.ID.CompareTo(y.ID));

            Console.WriteLine("Customers after sorting by ID");
            foreach (Customer customer in listCutomers)
            {
                Console.WriteLine(customer.ID);
            }

            listCutomers.Reverse();
            Console.WriteLine("Customers in descending order of ID");
            foreach (Customer customer in listCutomers)
            {
                Console.WriteLine(customer.ID);
            }
        }

        // Approach 1 - Step 1
        // Method that contains the logic to compare customers
        private static int CompareCustomers(Customer c1, Customer c2)
        {
            return c1.ID.CompareTo(c2.ID);
        }
    }
}
