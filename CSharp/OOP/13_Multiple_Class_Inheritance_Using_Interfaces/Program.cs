namespace _13_Multiple_Class_Inheritance_Using_Interfaces
{
    interface IA 
    {
        void AMethod();
    }

    class A : IA
    {
        public void AMethod()
        {
            Console.WriteLine("A");
        }
    }

    interface IB
    {
        void BMethod();
    }

    class B : IB
    {
        public void BMethod()
        {
            Console.WriteLine("B");
        }
    }

    class AB : IA, IB //A, B -> this not allow to have multiple class inherintaces, so we use interface instead
    {
        A a = new A();
        B b = new B();
        public void AMethod()
        {
            a.AMethod();
        }

        public void BMethod()
        {
            b.BMethod();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //we use interface for mutilple inheritance for classes
            AB ab = new AB();
            ab.AMethod();
            ab.BMethod();
        }
    }
}
