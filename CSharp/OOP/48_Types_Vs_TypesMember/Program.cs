namespace _48_Types_Vs_TypesMember
{

    /// <summary>
    /// this is "Types"
    /// can have "internal" or "public"
    /// cant have "private", "protected", "internal protected"
    /// </summary>
    public class CustomerAssemblyClassOne
    {
        /// <summary>
        /// this is "Types Member"
        /// 
        /// procted must be access via derived class
        /// </summary>
        protected string Name { get; set; }

        /// <summary>
        /// it can be access in with other/same assembely if it derived it
        /// </summary>
        protected internal int Age { get; set; }

        /// <summary>
        /// access inside containing class
        /// </summary>
        private int BirthDay { get; set; }

        /// <summary>
        /// access inside assembly
        /// </summary>
        internal string LastName { get; set; }

        /// <summary>
        /// access to anywhere
        /// </summary>
        public int BirthMonth { get; set; }
        public void SetName(string name)
        {
            Name = name;
        }
    }
    public class LoyalCustomer : CustomerAssemblyClassOne
    {
        public int Point { get; set; }
        public void PrintPoint()
        {
            Console.WriteLine("Name :{0}, Point :{1}", Name, Point);
        }
    }
    public class BadCustomer : CustomerAssemblyClassOne
    {
        public BadCustomer()
        {
            base.LastName = null;//can access becoz in same assembly (access via assembly only)
            base.Name = "Ammar";//can access protected can access via derived class
            base.Age = 1;
        }
    }

    internal class CustomerAssemblyClassTwo
    {
        public int BirthDay { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerAssemblyClassOne customer = new CustomerAssemblyClassOne();
            customer.Age = 1;
            customer.LastName = "Aziz";
            //customer.Name = "Test"; //sytanx error since proctected, u can access via derived class/ inside class

            LoyalCustomer loyalCustomer = new LoyalCustomer();
            loyalCustomer.SetName("Ammar");
            loyalCustomer.PrintPoint();//access name in derived method
        }
    }
}
