namespace _16_Multi_Cast_Delegates
{
    public delegate void SampleDelegate();

    public delegate int SampleIntegerDelegate();
    public delegate void SampleIntegerOutputDelegate(out int Integer);
    internal class Program
    {
        
        static void Main(string[] args)
        {
            #region Example 1
            Console.WriteLine("Example 1");
            //void type
            SampleDelegate del1, del2, del3, del4, del5;
            del1 = new SampleDelegate(SampleMethodOne);
            del2 = new SampleDelegate(SampleMethodTwo);
            del3 = new SampleDelegate(SampleMethodThree);
            del5 = new SampleDelegate(SampleMethodFive);

            del4 = del1 + del2 + del3;
            del4();
            #endregion

            #region Example 2
            Console.WriteLine("\nExample 2");
            SampleDelegate del = new SampleDelegate(SampleMethodOne);

            del += SampleMethodFive;
            del += new SampleDelegate(SampleMethodTwo); //different syntax
            del();
            #endregion

            #region Example 3 Integer
            Console.WriteLine("\ndel5 remove from del4");
            del4 = del4 - del5;//even we not add SampleMethodFive (del5) to del4, when we delete from del4,
                               //no error, just it not remove anythingsd
            del4();

            SampleIntegerDelegate delInt = new SampleIntegerDelegate(SampleMethodIntegerOne);
            delInt += SampleMethodIntegerTwo;
            delInt();

            int DelegateReturnedValue = delInt(); 
            Console.WriteLine("\nDelegateReturnedValue = {0}", DelegateReturnedValue); //it will returned 2 since it
                                                                                       //invoked last method from delegate

            #endregion

            #region Example 4 Output params
            //Output params
            SampleIntegerOutputDelegate delIntOutput = new SampleIntegerOutputDelegate(SampleMethodIntegerOutputParamTwo);
            delIntOutput += SampleMethodIntegerOutputParamOne;
            int DelegateReturnedOutputValue = -1;

            delIntOutput(out DelegateReturnedOutputValue);

            Console.WriteLine("\nDelegateReturnedOutputValue = {0}", DelegateReturnedOutputValue); //it will returned 1 same reason as above
            #endregion
        }


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

        /// <summary>
        /// Integer
        /// </summary>
        public static void SampleMethodFive()
        {
            Console.WriteLine("SampleMethodFive invoked");
        }

        public static int SampleMethodIntegerOne()
        {
            return 1;
        }

        public static int SampleMethodIntegerTwo()
        {
            return 2;
        }

        /// <summary>
        /// Way of output param
        /// </summary>
        /// <param name="Number"></param>
        public static void SampleMethodIntegerOutputParamOne(out int Number)
        {
            Number = 1;
        }

        public static void SampleMethodIntegerOutputParamTwo(out int Number)
        {
            Number = 2;
        }
    }
}
