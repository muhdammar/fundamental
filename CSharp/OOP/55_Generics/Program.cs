namespace _55_Generics
{
    // This program demonstrates three different approaches to implementing equality comparison:
    // 1. Type-specific (int only)
    // 2. Object type (allows any type but has boxing/unboxing overhead)
    // 3. Generic (type-safe and no boxing)

    internal class Program
    {
        static void Main(string[] args)
        {
            // Testing type-specific comparison (integers only)
            bool result1 = Calculator.AreEqual(5, 5);
            Console.WriteLine($"Basic int comparison: {result1}");

            // Testing object comparison (works with any type but has boxing overhead)
            bool result2 = Calculator.AreEqualObject("test", "test");
            Console.WriteLine($"Object comparison: {result2}");

            // Testing generic comparison (type-safe, no boxing)
            bool result3 = Calculator.AreEqualGeneric<string>("hello", "hello");
            Console.WriteLine($"Generic comparison: {result3}");
        }
    }

    public class Calculator
    {
        // Basic implementation - only works with integers
        // Compile-time error if used with other types
        public static bool AreEqual(int value1, int value2)
        {
            return value1 == value2;
        }

        // Object implementation - works with any type but:
        // 1. Not type-safe (can compare string to int)
        // 2. Boxing/unboxing causes performance overhead for value types
        public static bool AreEqualObject(object value1, object value2)
        {
            return value1 == value2;
        }

        // Generic implementation benefits:
        // 1. Type-safe (compiler enforces same type for both parameters)
        // 2. No boxing for value types
        // 3. Works with any type that implements Equals()
        public static bool AreEqualGeneric<T>(T value1, T value2)
        {
            return value1.Equals(value2);
        }
    }
}
