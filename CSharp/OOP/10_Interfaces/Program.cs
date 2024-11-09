//Kudvenkat tutorial about interface is obselete
//since C# 8.0 got some new features for interface

namespace _10_Interfaces
{
    // Before C# 8.0
    interface IOutdatedInterface
    {
        // In previous versions of C#, interface methods could only contain signatures, not implementations.
        // All interface methods are implicitly public and abstract (i.e., they have no body).
        void Print();  // This method must be implemented in any class that implements this interface
    }

    class Class1 : IOutdatedInterface
    {
        public void Print()
        {
            // Implement the method from the interface
            Console.WriteLine("[IOutdatedInterface] Implemented Print Method in Class1");
        }
    }

    // After C# 8.0 - Advanced interface features
    interface ILatestInterface
    {
        // Property with a getter
        public string Name { get;}

        // Property with a getter and setter (auto-implemented properties are allowed in interfaces now)
        public string OtherProperty { get; set; }

        // A default method implementation in the interface
        public void Print()
        {
            // We can call the private Log method inside this default method.
            Log("This is a log message from Print method.");
            Console.WriteLine("Default Print Method from ILatestInterface");
        }

        // Private method implementation in the interface (only callable within the interface itself)
        private void Log(string message)
        {
            Console.WriteLine($"Log from ILatestInterface: {message}");
        }

        public void CallLog()
        {

            Console.WriteLine($"callLog from ILatestInterface");
            Log("calling private Log() from interface");
        }

        // Static method in the interface (C# 8.0+ feature)
        /// <summary>
        /// Question: "Why Static Methods in Interfaces Don't Force Class Implementation?"
        /// A static method in an interface is part of the interface's type, not an instance method. 
        /// The method is not inherited by the class, and therefore, the class does not need to implement it.
        /// Unlike static class, we cannot mix instance member and static together in static Class, but for interface, it possible
        /// </summary>
        public static void StaticMethod()
        {
            Console.WriteLine("Static Method in ILatestInterface");
        }

        string Description { get; } //getter is required, setter is optional, if u remove get, and add setter, it will return error;

        /// <summary>
        /// this will force all inherit derived class need to implement this method since this interface method dont have body/implementation
        /// </summary>
        void PrintOther();

    }

    class Class2 : ILatestInterface
    {
        // Implementing the required auto-implemented property from the interface
        public string Name { get; set; }

        public string Description { get; set; } //it allowable even interface not have setter
        public string OtherProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        // Overriding the default Print method
        public void Print()
        {
            Console.WriteLine("Overridden Print Method in Class2");
        }

        public void PrintOther()
        {
            throw new NotImplementedException();
        }
    }

    class Class3 : ILatestInterface
    {
        // Implementing the required auto-implemented property from the interface
        public string Name { get; set; }

        public string Description { get; set; } //it allowable even interface not have setter
        public string OtherProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void PrintOther()
        {
            throw new NotImplementedException();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Outdate features from old c# version
            Class1 outdateClass = new Class1();
            outdateClass.Print();




            Class2 latestClass = new Class2();
            latestClass.Print();

            ILatestInterface latestInterface = new Class2();
            //latestInterface.Name = "test"; // syntax error since latest interface is read only
            latestInterface.Print();
            ILatestInterface.StaticMethod(); //static method in interface
            Console.WriteLine(latestInterface.Name);


            Class2 classLastestInterface = new Class2();
            classLastestInterface.Name = "test 2";
            Console.WriteLine(classLastestInterface.Name); //this is working since class got setter, even the interface inherit only got getter

            classLastestInterface.Name = "test 3";
            ILatestInterface latestInterface2 = classLastestInterface;
            Console.WriteLine(latestInterface2.Name); //this is working since interface got getter, and it point to class reference type;
            latestInterface2.CallLog(); //call method directly from interface even got reference type from class that inherit that interface

            ILatestInterface latestInterface3 = new Class3();
            latestInterface3.Print(); //this will call interface Print Method since Class 3 not override the Print Method
        }
    }
}