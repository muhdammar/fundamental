using System;

namespace StepwiseBuilder
{
    public enum CarType
    {
        Sedan,
        Crossover
    };

    public class Car
    {
        public CarType Type;
        public int WheelSize;

        public override string ToString()
        {
            return $"Car Type: {Type}, Wheel Size: {WheelSize} inches";
        }
    }

    // Step 1: Must specify car type
    public interface ISpecifyCarType
    {
        public ISpecifyWheelSize OfType(CarType type);
    }

    // Step 2: Must specify wheel size
    public interface ISpecifyWheelSize
    {
        public IBuildCar WithWheels(int size);
    }

    // Final step: Can build the car
    public interface IBuildCar
    {
        public Car Build();
    }

    public class CarBuilder
    {
        // Entry point of the builder
        public static ISpecifyCarType Create()
        {
            return new Impl();
        }

        // Private implementation that handles the actual building
        private class Impl :
            ISpecifyCarType,
            ISpecifyWheelSize,
            IBuildCar
        {
            private Car car = new Car();

            public ISpecifyWheelSize OfType(CarType type)
            {
                car.Type = type;
                return this;
            }

            public IBuildCar WithWheels(int size)
            {
                switch (car.Type)
                {
                    case CarType.Crossover when size < 17 || size > 20:
                        throw new ArgumentException($"Crossover wheel size must be between 17 and 20 inches. Got {size}.");
                    case CarType.Sedan when size < 15 || size > 17:
                        throw new ArgumentException($"Sedan wheel size must be between 15 and 17 inches. Got {size}.");
                }
                car.WheelSize = size;
                return this;
            }

            public Car Build()
            {
                return car;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Stepwise Car Builder Demo\n");

            // Example 1: Building a valid Crossover
            Console.WriteLine("1. Building a Crossover with 18-inch wheels:");
            try
            {
                var crossover = CarBuilder.Create()
                    .OfType(CarType.Crossover)
                    .WithWheels(18)
                    .Build();
                Console.WriteLine($"Success! {crossover}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine();

            // Example 2: Building a valid Sedan
            Console.WriteLine("2. Building a Sedan with 16-inch wheels:");
            try
            {
                var sedan = CarBuilder.Create()
                    .OfType(CarType.Sedan)
                    .WithWheels(16)
                    .Build();
                Console.WriteLine($"Success! {sedan}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine();

            // Example 3: Attempting to build a Crossover with invalid wheels
            Console.WriteLine("3. Trying to build a Crossover with 16-inch wheels (should fail):");
            try
            {
                var invalidCrossover = CarBuilder.Create()
                    .OfType(CarType.Crossover)
                    .WithWheels(16)
                    .Build();
                Console.WriteLine($"Unexpected success: {invalidCrossover}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Failed as expected: {ex.Message}");
            }
            Console.WriteLine();

            // Example 4: Attempting to build a Sedan with invalid wheels
            Console.WriteLine("4. Trying to build a Sedan with 18-inch wheels (should fail):");
            try
            {
                var invalidSedan = CarBuilder.Create()
                    .OfType(CarType.Sedan)
                    .WithWheels(18)
                    .Build();
                Console.WriteLine($"Unexpected success: {invalidSedan}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Failed as expected: {ex.Message}");
            }

            // Note: The following would not compile:
            // var car = CarBuilder.Create().WithWheels(16).OfType(CarType.Sedan).Build();
            // Because the interfaces enforce the correct order of operations
        }
    }
}