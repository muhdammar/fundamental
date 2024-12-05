using static System.Console;

namespace _3_Liskov_Subtitution_Principle
{
    /// <summary>
    /// DISCLAIMER THIS EXAMPLE IS BAD EXAMPLE FROM UDEMY -> SO LETS LEARN WHY IT BAD EXAMPLE
    /// </summary>
    // using a classic example
    public class Rectangle
    {
        //public int Width { get; set; }
        //public int Height { get; set; }


        //make it virtual to able override in inherit class
        //if we remove virtual, syntax will happen, since we use override in inherit class
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle()
        {

        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    /// <summary>
    /// 1# FIRST VIOLATION -> SQUARE NOT HAVE SAME BEHAVIOUR LIKE RECTANGLE
    /// </summary>
    public class Square : Rectangle
    {
        //this will cause an issue if not override since it will take parent base value
        //public new int Width
        //{
        //  set { base.Width = base.Height = value; }
        //}

        //public new int Height
        //{ 
        //  set { base.Width = base.Height = value; }
        //}


        /// <summary>
        /// we need to override value even we call rectangle as object reference
        /// </summary>
        public override int Width // nasty side effects
        {
            set { base.Width = base.Height = value; }
        }

        public override int Height
        {
            set { base.Width = base.Height = value; }
        }
    }

    public class Demo
    {
        static public int Area(Rectangle r) => r.Width * r.Height;

        static void Main(string[] args)
        {
            Rectangle rc = new Rectangle(2, 3);
            WriteLine($"{rc} has area {Area(rc)}");

            // should be able to substitute a base type for a subtype
            /*Square*/

            /// 2# 2ND VIOLATION -> SQUARE EXPECTED BEHAVIOUR WILL NOT SAME SINCE IT OVERRIDE THE HEIGHT AFTER SET THE WIDTH
            Rectangle sq = new Square();
            sq.Width = 4;
            sq.Height = 5;// Unexpected behavior! Area is 25, not 20 (4 x 5)
            WriteLine($"{sq} has area {Area(sq)}");
        }
    }
}
