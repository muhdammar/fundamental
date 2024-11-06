using System.Xml.Linq;

namespace _07_01_Properties
{
    public class Student
    {
        // Private fields
        private int _id;
        private string _name;
        private double _passMark = 35;

        public void SetId(int Id)
        {
            if(Id <= 0)
            {
                throw new ArgumentException("Student Id should be greater than zero");
            }   
            this._id = Id;
        }

        public int GetId()
        {
            return this._id;
        }

        public void SetName(string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new Exception("Name cannot be null or empty");
            }
            this._name = Name;
        }

        public string GetName()
        {
            if(string.IsNullOrEmpty(this._name)) //can change to tertiary condition if u want
            {
                return "No Name";
            }
            return this._name;
        }

        public double GetPassMark()
        {
            return this._passMark;
        }
    }

    class Program
    {
        static void Main()
        {
            Student C1 = new Student();
            C1.SetId(1);
            Console.WriteLine("Student Id = {0}", C1.GetId());
            Console.WriteLine("Student Name = {0}", C1.GetName());
            C1.SetName("Ammar");
            Console.WriteLine("Student Name after change = {0}", C1.GetName());
            Console.WriteLine("Pass mark = {0}", C1.GetPassMark());
            //C1.SetName(null);//uncomment this to remove syntax error
        }
    }
}
