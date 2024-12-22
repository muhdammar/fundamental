using System.Reflection;

namespace _53_Reflection
{
    public class MainClass
    {
        private static void Main()
        {
            // Get the Type using GetType() static method
            Type T = Type.GetType("_53_Reflection.Customer");

            //#2 Second Way
            //Customer C1 = new Customer();
            //Type T = C1.GetType();

            //#3 Third Way
            //Type T = typeof(Customer);

            if (T == null) {
                Console.WriteLine("Type not found");
                return;
            }
            
            // Print the Type details
            Console.WriteLine("Full Name = {0}", T.FullName);
            Console.WriteLine("Just the Class Name = {0}", T.Name);
            Console.WriteLine("Just the Namespace = {0}", T.Namespace);
            Console.WriteLine();

            // Print the list of Methods
            Console.WriteLine("Methods in Customer Class");
            MethodInfo[] methods = T.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.ReturnType.Name + " " + method.Name);
            }
            Console.WriteLine();

            // Print the Properties
            Console.WriteLine("Properties in Customer Class");
            PropertyInfo[] properties = T.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(property.PropertyType.Name + " " + property.Name);
            }
            Console.WriteLine();

            // Print the Constructors
            Console.WriteLine("Constructors in Customer Class");
            ConstructorInfo[] constructors = T.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine(constructor.ToString());
            }
        }
    }

    public class Customer
    {
        /// <summary>
        /// behind the scene, c# will create set_Id, and get_Id
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }

        public Customer(int ID, string Name)
        {
            this.Id = ID;
            this.Name = Name;
        }

        public Customer()
        {
            this.Id = -1;
            this.Name = string.Empty;
        }

        public void PrintID()
        {
            Console.WriteLine("ID = {0}", this.Id);
        }

        public void PrintName()
        {
            Console.WriteLine("Name = {0}", this.Name);
        }
    }
}
