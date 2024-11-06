namespace _08_Structs
{
    public struct Student
    {
        // Private fields
        private int _id;
        private string _name;
        private double _passMark = 35;

        /// <summary>
        /// read/write property
        /// </summary>
        public int Id
        {
            //this call accessor
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Student Id should be greater than zero");
                }
                this._id = value;
            }
            get
            {
                return this._id;

            }
        }

        public string Name
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Name cannot be null or empty");
                }
                this._name = value;
            }
            get
            {
                return string.IsNullOrEmpty(this._name) ? "No Name" : this._name;
            }
        }


        /// <summary>
        /// read only accessor
        /// </summary>
        public double PassMark
        {
            get { return this._passMark; }
        }

        public Student(int Id, string Name)
        {
            this._id = Id;
            this._name = Name;
        }
    }

    class Program
    {
        static void Main()
        {
            Student C1 = new Student();
            C1.Id = 1;
            Console.WriteLine("Student Id = {0}", C1.Id);
            Console.WriteLine("Student Name = {0}", C1.Name);
            C1.Name = "Ammar";

            Console.WriteLine("Student Name after change = {0}", C1.Name);
            Console.WriteLine("Pass mark = {0}", C1.PassMark);
            //C1.SetName(null);//uncomment this to remove syntax error
        }
    }
}
