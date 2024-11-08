namespace _09_Structs_VS_Classes
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }

        ~Customer() {
            Console.WriteLine("Customer destructor was called");
        } 
    }

    public struct Student
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //~Student() { } //uncomment this to see error ->Only class types can contain destructors
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //#1Structs is value type
            //Value type is like int
            //example

            //this is value type, is managed on stack, making this faster to allocate and deallocate
            //Once out of scope, they are removed from memory.
            //"out of scope" meaning bila dia gi line bawah je dia terus deallocate
            int i = 0;

            if (i == 0) { 
                int j = 10;

                //CLASS is reference type
                Customer c1 = new Customer();
                c1.ID = 101;
                c1.Name = "Ammar";

                Console.WriteLine("Customer C1 Name: {0}", c1.Name);//Output: C1: Ammar

                Customer c2 = new Customer();
                c2.Name = "Abu";
                Console.WriteLine("Before assigning C1 to Customer C2 Name: {0}", c2.Name);//Output: C2: Abu

                //this class was object reference, was managed by garbage collector
                c2 = c1;
                Console.WriteLine("After assigning C1 Customer C2 Name: {0}", c2.Name); //Output: C2: Ammar

                c1.Name = "Nama baru";
                Console.WriteLine("After change C1 Customer Name, C2 will follow since it reference type: {0}", c2.Name); //Output: C2: Nama baru
            }

            Student studentStruct = new Student();

            studentStruct.Name = "struct 1";
            Console.WriteLine("After change Struct {0}", studentStruct.Name);
            Student studentStructV2 = new Student();
            studentStructV2 = studentStruct;

            Console.WriteLine("After assigning C1 Customer C2 Name: {0}", studentStructV2.Name); //Output: struct 1

            studentStruct.Name = "struct 1 enhancement";
            Console.WriteLine("After change struct 1: {0}", studentStruct.Name); //Output: struct 1 //not change
            Console.WriteLine("After change struct 1, struct 2 will not follow since it not reference type: {0}", studentStructV2.Name); //Output: struct 1 //not change

        }
    }
}
