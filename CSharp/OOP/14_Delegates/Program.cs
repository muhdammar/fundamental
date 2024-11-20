namespace _14_Delegates
{
    public delegate void HelloFunctionDelegate(string Message);

    internal class Program
    {
        static void Main(string[] args)
        {
            //A delegate is a type safe function pointer

            //this delegate is function pointer to "Hello" function
            //HelloFunctionDelegate del = new HelloFunctionDelegate(Hello); //uncommented to see error
            HelloFunctionDelegate del = new HelloFunctionDelegate(Hello2); //no syntax error
            del("Hello from Delegate");
        }
        //this will return error to HelloFunctionDelegate since not match the return type
        //thats why it called type safe pointer
        public static string Hello(string text)
        {
            Console.WriteLine(text);
            return text;
        }
        public static void Hello2(string text)
        {
            Console.WriteLine(text);
        }
    }
}
