using System;

namespace BuilderInheritanceWithRecursive
{
    /// <summary>
    /// The main Person class that we want to build.
    /// This demonstrates how to implement a nested Builder class that serves as the entry point.
    /// </summary>
    public class Person
    {
        // Properties that we want to set using our builder
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Nested Builder class that inherits from the most specialized builder.
        /// This is the concrete implementation that completes our builder hierarchy.
        /// </summary>
        public class Builder : PersonBirthDateBuilder<Builder>
        {
            // Internal constructor prevents external instantiation
            internal Builder() { }
        }

        // Static property that serves as the entry point for our fluent builder
        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    /// <summary>
    /// Base abstract builder class that holds the Person instance being built.
    /// All other builders will inherit from this class.
    /// </summary>
    public abstract class PersonBuilder
    {
        // Protected person instance that will be built up
        protected Person person = new Person();

        // Method to return the final built Person object
        public Person Build()
        {
            return person;
        }
    }

    /// <summary>
    /// First level of the builder hierarchy - handles setting the person's name.
    /// Uses recursive generics pattern with SELF type parameter.
    /// </summary>
    /// <typeparam name="SELF">The type of the most derived builder in the hierarchy</typeparam>
    public class PersonInfoBuilder<SELF> : PersonBuilder
        where SELF : PersonInfoBuilder<SELF>
        // This constraint means: SELF must be a type that inherits from PersonInfoBuilder<SELF>
        // This creates a recursive generic constraint that ensures type safety
    {
        /// <summary>
        /// Sets the person's name and returns the builder instance.
        /// </summary>
        /// <param name="name">The name to set</param>
        /// <returns>The current builder instance cast to SELF type</returns>
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;  // Cast to SELF type allows method chaining
        }
    }

    /// <summary>
    /// Second level of the builder hierarchy - handles setting the person's job.
    /// Inherits from PersonInfoBuilder using its own type wrapped in PersonInfoBuilder.
    /// </summary>
    /// <typeparam name="SELF">The type of the most derived builder in the hierarchy</typeparam>
    public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>>
        where SELF : PersonJobBuilder<SELF>
        // Notice how we pass PersonJobBuilder<SELF> as the type parameter to PersonInfoBuilder
        // This maintains the chain of builder functionality
    {
        /// <summary>
        /// Sets the person's job position and returns the builder instance.
        /// </summary>
        /// <param name="position">The job position to set</param>
        /// <returns>The current builder instance cast to SELF type</returns>
        public SELF WorksAsA(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }

    /// <summary>
    /// Third level of the builder hierarchy - handles setting the person's birth date.
    /// Inherits from PersonJobBuilder using its own type wrapped in PersonJobBuilder.
    /// </summary>
    /// <typeparam name="SELF">The type of the most derived builder in the hierarchy</typeparam>
    public class PersonBirthDateBuilder<SELF> : PersonJobBuilder<PersonBirthDateBuilder<SELF>>
        where SELF : PersonBirthDateBuilder<SELF>
        // The pattern continues: we pass PersonBirthDateBuilder<SELF> to PersonJobBuilder
        // This allows us to have access to all previous builder methods while adding new ones
    {
        /// <summary>
        /// Sets the person's birth date and returns the builder instance.
        /// </summary>
        /// <param name="dateOfBirth">The birth date to set</param>
        /// <returns>The current builder instance cast to SELF type</returns>
        public SELF Born(DateTime dateOfBirth)
        {
            person.DateOfBirth = dateOfBirth;
            return (SELF)this;
        }
    }

    /// <summary>
    /// Main program demonstrating the builder pattern usage
    /// </summary>
    internal class Program
    {
        // Example of creating a custom builder that inherits from the builder hierarchy
        class SomeBuilder : PersonBirthDateBuilder<SomeBuilder>
        {
            // Empty class - gets all functionality from base classes
            // Could add additional building methods here
        }

        public static void Main(string[] args)
        {
            // Example usage of the builder pattern
            var me = Person.New          // Start with a new builder
                .Called("Dmitri")        // Set name (from PersonInfoBuilder)
                .WorksAsA("Quant")       // Set job (from PersonJobBuilder)
                .Born(DateTime.UtcNow)   // Set birth date (from PersonBirthDateBuilder)
                .Build();               // Create the final Person instance

            Console.WriteLine(me);

            // The beauty of this pattern is that we can:
            // 1. Add new builder levels without modifying existing code
            // 2. Use any level of the builder hierarchy independently
            // 3. Maintain a fluent interface throughout the entire chain
        }
    }
}