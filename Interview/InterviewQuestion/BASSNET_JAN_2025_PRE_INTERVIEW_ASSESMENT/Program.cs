using System.ComponentModel;
using System.Linq;

namespace BASSNET_JAN_2025_PRE_INTERVIEW_ASSESMENT
{
    //Question 1:
    //You are given an integer where each digit or a pair of digits can be mapped to a corresponding letter: 
    //The digit `1` is mapped to the letter `a`, `2 to `b`, …., up to `26`, which is mapped to the letter `z`. 
    //For examples, the number 12258 can be translated to “abbeh”, “aveh”, “abyh”, “lbeh” and “lyh”, so there are 5 different ways to translate 12258. 
    //How to write a function/method to count the different ways to translate a number?

    //Answer



    /// <summary>
    /// Question 2
    /// </summary>
    /*
        ####### Customer List for date 09/01/2024 #####

        ====== Customer List =======
        Customer : Customer Name : Terry Poh (3) - 2 rooms required.
        Customer : Customer Name : Leong Sean (8) - 4 rooms required.

        ====== ROOM Required =======
        6
    */
    public class Reservation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ReserveDate { get; set; }
        public int Pax { get; set; }
        public static List<Reservation> reserve = new List<Reservation>()
            {
              new Reservation() { FirstName = "Jack", LastName = "Lim", ReserveDate = new DateTime(2024, 01, 05, 23, 15, 00), Pax = 10},
              new Reservation() { FirstName = "Lee", LastName = "Foo", ReserveDate = new DateTime(2023, 03, 04, 19, 00, 00), Pax = 5},
              new Reservation() { FirstName = "Terry", LastName = "Poh", ReserveDate = new DateTime(2024, 01, 09, 10, 00, 00), Pax = 3},
              new Reservation() { FirstName = "Leong", LastName = "Sean", ReserveDate = new DateTime(2024, 01, 09, 12, 30, 00), Pax = 8}
            };
        public int getRoomRequired()
        {
            return (Pax / 2) + (Pax % 2);
        }
        public string getFullName()
        {
            return FirstName + " " + LastName;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var reservations = Reservation.reserve;

            var reservationDate = reservations.OrderBy(x => x.ReserveDate).GroupBy(x => x.ReserveDate.ToString("dd/MM/yyyy"))
                .ToList();
            foreach (var date in reservationDate)
            {
                int countTotal = 0;
                Console.WriteLine("####### Customer List for date {0} #####", date.Key);
                Console.WriteLine("====== Customer List =======");
                foreach (var room in date )
                {
                    int requiredRoom = room.getRoomRequired();
                    string fullName = room.getFullName();
                    Console.WriteLine("Customer: Customer Name:{0} ({1}) - ({2}) rooms required.",fullName , room.Pax, requiredRoom);
                    countTotal = countTotal + requiredRoom;
                }
                Console.WriteLine("====== ROOM Required =======");
                Console.WriteLine(countTotal);
                Console.WriteLine();
            }
        }
    }
 }
