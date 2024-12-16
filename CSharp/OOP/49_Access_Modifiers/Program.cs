using _48_Types_Vs_TypesMember;

namespace _49_Access_Modifiers
{
    public class SavingCustomer : CustomerAssemblyClassOne {
        public SavingCustomer() {
            //CAUTIONS SYNTAX ERROR
            base.LastName = null;//cant access internal access modifier in "_48_Types_Vs_TypesMember" since it is internal (access via assembly only)
            base.Age = 1; //can access this protected internal modifier from other assembly since it derived
            base.Name = "Ammar";//can access protected via derived class even different accesemby

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //u can call this since it public
            CustomerAssemblyClassOne customer = new CustomerAssemblyClassOne();

            //CAUTIONS SYNTAX ERROR
            customer.Age = 1; //u cant access age in customer since it protected internal, it can be access via derived class/in same assemlby
            Console.WriteLine("Hello, World!");

            //u cant call this class since it not available bcoz of internal in "_48_Types_Vs_TypesMember"
            CustomerAssemblyClassTwo customer2 = new CustomerAssemblyClassTwo();
        }
    }
}
