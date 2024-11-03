namespace _01_IntroductionToClasses
{
    class Customer
    {
        string _firstName;
        string _lastName;

        /// <summary>
        /// This is a constructor (must have the same name as the class).
        /// Used to initialize the object's properties with default values.
        /// Note: If no constructor is defined, a default constructor is automatically provided by the compiler.
        /// If constructor was defined, and we use empty constructor, it will return error since not meet the parameter in constructor
        /// Unless we create empty constructor too inside this class
        /// </summary>
        public Customer() : this("No First Name Provided", "No Last Name Provided")
        {
            //if we comment this, it will return error at line 44
            //this default will use other constructor that have parameter
        }

        /// <summary>
        /// Overloading constructor
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        public Customer(string FirstName, string LastName)
        {
            _firstName = FirstName;
            _lastName = LastName;

            //other ways
            this._firstName = FirstName; //this. is refer to Class Instance since more readable
        }
        public void PrintFullName()
        {
            Console.WriteLine("Full Name = {0}", _firstName + " " + _lastName);
        }

        /// <summary>
        /// Descructor used for cleanup any resource, automatic call by GC
        /// </summary>
        ~Customer()
        {
            //cleanup code
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //hadam code ni
            Customer customer = new Customer("Ammar", "Aziz");
            Customer customer2 = new Customer();
            customer.PrintFullName();
            customer2.PrintFullName();
        }
    }
}