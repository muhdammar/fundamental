using DemoLibrary;

namespace _5_Dependency_Inversion_Principle___BAD_EXAMPLE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VIOLATION: High-level configuration happens here in Main,
            // but all the dependencies are created inside the Chore class.
            // This means we have no control over what logger or emailer is used.

            Person owner = new Person
            {
                FirstName = "Tim",
                LastName = "Corey",
                EmailAddress = "tim@iamtimcorey.com",
                PhoneNumber = "555-1212"
            };

            // The Chore class should receive its dependencies through constructor
            // injection rather than creating them internally
            Chore chore = new Chore
            {
                ChoreName = "Take out the trash",
                Owner = owner
            };

            // When these methods are called, they create new instances of Logger
            // and Emailer inside, violating DIP since we can't inject different
            // implementations for testing or changing behavior
            chore.PerformedWork(3);
            chore.PerformedWork(1.5);
            chore.CompleteChore();
        }
    }
}
