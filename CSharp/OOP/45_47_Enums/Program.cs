namespace _45_47_Enums
{
    public class Program
    {
        public static void Main()
        {
            Customer[] customers = new Customer[3];
            customers[0] = new Customer()
            {
                Name = "Mark",
                Gender = Gender.Male
            };
            customers[1] = new Customer()
            {
                Name = "Mary",
                Gender = Gender.Female
            };
            customers[2] = new Customer()
            {
                Name = "Sam",
                Gender = Gender.Unknown
            };
            foreach (Customer customer in customers)
            {
                Console.WriteLine("Name = {0} && Gender = {1}", customer.Name, GetGender(customer.Gender));
            }

            //how to get values from enum
            short[] Values = (short[])Enum.GetValues(typeof(Gender));
            foreach (short value in Values)
                Console.WriteLine(value); //0,1,2

            //how to get names from enum
            string[] Names = Enum.GetNames(typeof(Gender));
            foreach(string name in Names)
                Console.WriteLine(name);//Unknown,Male,Female

            //enum casting
            Gender gender = (Gender)3;
            Console.WriteLine(gender); //if enum not found, it will return the value "3"

            gender = (Gender)2;
            Console.WriteLine(gender);//female

            int Num = (short)Gender.Unknown;
            Console.WriteLine(Num); //0

            //enum is strongly type, so this is not possible
            //Gender gender = Season.Winter;

            //this also can casting meh?? power2
            gender = (Gender) Season.Summer;//Summer = 2
            Console.WriteLine(gender);//Female since summer is 2
        }


        public static string GetGender(Gender gender)
        {
            // The swicth here is now more readable and maintainable because 
            // of replacing the integral numbers with Gender enum
            switch (gender)
            {
                case Gender.Unknown:
                    return "Unknown";
                case Gender.Male:
                    return "Male";
                case Gender.Female:
                    return "Female";
                default:
                    return "Invalid Data for Gender";
            }
        }
    }
    public enum Season : short
    {
        Winter = 1,
        Summer,
        Spring 
    }

    /// <summary>
    /// default value start with 0
    /// integer is default type for enum
    /// if no number specify, enum start with 0, increment by 1
    /// </summary>
    public enum Gender : short
    {
        Unknown = 0,
        Male = 1,
        Female = 2
    }


    public class Customer
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
    }

    //// Default underlying type is int and the value starts at ZERO
    //public enum Gender
    //{
    //    Unknown,
    //    Male,
    //    Female
    //}


    //// Gender enum underlying type is now short and the value starts at ONE
    //public enum Gender : short
    //{
    //    Unknown = 1,
    //    Male = 2,
    //    Female = 3
    //}


    //// Enum values need not be in sequential order. Any valid underlying type value is allowed 
    //public enum Gender : short
    //{
    //    Unknown = 10,
    //    Male = 22,
    //    Female = 35
    //}


    //// This enum will not compile, bcos the maximum value allowed for short data type is 32767. 
    //public enum Gender : short
    //{
    //    Unknown = 10,
    //    Male = 32768,
    //    Female = 35
    //}
}

