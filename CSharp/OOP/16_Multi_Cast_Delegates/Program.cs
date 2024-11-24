namespace _16_Multi_Cast_Delegates
{
    public delegate void SampleDelegate();
    internal class Program
    {
        public static void SampleMethodOne()
        {
            Console.WriteLine("SampleMethodOne invoked");
        }

        public static void SampleMethodTwo()
        {
            Console.WriteLine("SampleMethodTwo invoked");
        }

        public static void SampleMethodThree()
        {
            Console.WriteLine("SampleMethodThree invoked");
        }

        public static void SampleMethodFive()
        {
            Console.WriteLine("SampleMethodFour invoked");
        }
        static void Main(string[] args)
        {
            SampleDelegate del1, del2, del3, del4, del5;
            del1 = new SampleDelegate(SampleMethodOne);
            del2 = new SampleDelegate(SampleMethodTwo);
            del3 = new SampleDelegate(SampleMethodThree);
            del5 = new SampleDelegate(SampleMethodFive);

            del4 = del1 + del2 + del3;
            del4();

            Console.WriteLine("\ndel5 remove from del4");
            del4 = del4 - del5;//even we not add SampleMethodFive (del5) to del4, when we delete from del4,
                               //no error, just it not remove anything
            del4();
        }
    }
}
