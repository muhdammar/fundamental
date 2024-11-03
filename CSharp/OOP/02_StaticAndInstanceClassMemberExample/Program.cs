namespace _02_StaticAndInstanceClassMemberExample
{
    class Circle
    {
        //change to static since it not change,
        //so can save resource in Memory, if not used static, it will copy new resource as instance created to Memory
        //float _PI = 3.141F; 

        /// <summary>
        /// //use static to make 1 copy for all instances created
        /// use public modifier to access it outside class
        /// </summary>
        public static float _PI; 
        int _Radius;

        static Circle()
        {
            //this automatically initialized even not called
            Console.WriteLine("Static constructor initialized");
            Circle._PI = 3.141F;
        }

        public Circle(int Radius)
        {
            Console.WriteLine("non static constructor initialized");
            this._Radius = Radius;
        }

        public float CalculateArea() 
        {
            return Circle._PI * this._Radius * this._Radius;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Circle c1  = new Circle(5);
            float area1 = c1.CalculateArea();
            Console.WriteLine("Area1 = {0}", area1);

            Circle c2 = new Circle(10);
            float area2 = c2.CalculateArea();
            Console.WriteLine("Area2 = {0}", area2);
        }
    }
}