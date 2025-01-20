namespace BASSNET_JAN_2025_PRE_INTERVIEW_ASSESMENT_Q1
{
    public class NumberTranslator
    {
        private string Number { get; }

        public NumberTranslator(string number)
        {
            Number = number;
        }

        // Method 1: Convert digit by digit
        public string TranslateMethod1()
        {
            string result = "";
            for (int i = 0; i < Number.Length; i++)
            {
                if (i + 1 <= Number.Length)
                {
                    int digit = int.Parse(Number[i].ToString());
                    result += (char)('a' + digit - 1);
                }
            }
            return result;
        }

        // Method 2: Convert after 1st character, take 2 characters for the rest
        public string TranslateMethod2()
        {
            string result = "";
            result += (char)('a' + int.Parse(Number[0].ToString()) - 1);

            int twoDigit = int.Parse(Number.Substring(1, 2));
            result += (char)('a' + twoDigit - 1);

            for (int i = 3; i < Number.Length; i++)
            {
                int digit = int.Parse(Number[i].ToString());
                result += (char)('a' + digit - 1);
            }
            return result;
        }

        // Method 3: Convert after 2nd character and convert the rest
        public string TranslateMethod3()
        {
            string result = "";
            for (int i = 0; i < 2; i++)
            {
                int digit = int.Parse(Number[i].ToString());
                result += (char)('a' + digit - 1);
            }

            int twoDigit = int.Parse(Number.Substring(2, 2));
            result += (char)('a' + twoDigit - 1);

            int lastDigit = int.Parse(Number[4].ToString());
            result += (char)('a' + lastDigit - 1);

            return result;
        }

        // Method 4: Convert first 2 characters and convert the rest
        public string TranslateMethod4()
        {
            string result = "";
            int firstTwoDigit = int.Parse(Number.Substring(0, 2));
            result += (char)('a' + firstTwoDigit - 1);

            for (int i = 2; i < Number.Length; i++)
            {
                int digit = int.Parse(Number[i].ToString());
                result += (char)('a' + digit - 1);
            }
            return result;
        }

        // Method 5: Convert 2 characters and count the last one
        public string TranslateMethod5()
        {
            string result = "";
            int firstTwoDigit = int.Parse(Number.Substring(0, 2));
            result += (char)('a' + firstTwoDigit - 1);

            int secondTwoDigit = int.Parse(Number.Substring(2, 2));
            result += (char)('a' + secondTwoDigit - 1);

            int lastDigit = int.Parse(Number[4].ToString());
            result += (char)('a' + lastDigit - 1);

            return result;
        }

        public void DisplayAllTranslations()
        {
            Console.WriteLine($"Number: {Number}");
            Console.WriteLine("1. TranslateMethod1: " + TranslateMethod1());
            Console.WriteLine("2. TranslateMethod2:  " + TranslateMethod2());
            Console.WriteLine("3. TranslateMethod3:  " + TranslateMethod3());
            Console.WriteLine("4. TranslateMethod4:  " + TranslateMethod4());
            Console.WriteLine("5. TranslateMethod5:   " + TranslateMethod5());
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var translator = new NumberTranslator("12258");
            translator.DisplayAllTranslations();
        }
    }
}
