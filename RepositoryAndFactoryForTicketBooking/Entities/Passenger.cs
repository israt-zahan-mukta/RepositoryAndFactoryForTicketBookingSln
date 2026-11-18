using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndFactoryForTicketBooking.Entities
{
    public class Passenger
    {
        public Passenger()
        {
        }

        public Passenger(int passengerID, string name, string email, SeatType type, Payment pay, double firstClassPrice, double economyPrice, int noOfSeat)
        {
            PassengerID = passengerID;
            Name = name;
            Email = email;
            Type = type;
            Pay = pay;
            FirstClassPrice = 45000;
            EconomyPrice = 30000;
            NoOfSeat = noOfSeat;
            CashBackPcnt = 0.15;
        }

        public int PassengerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public SeatType Type { get; set; }
        public Payment Pay { get; set; }
        public double FirstClassPrice { get; set; }
        public double EconomyPrice { get; set; }
        public int NoOfSeat { get; set; }
        public double TotalPayment { get; set; }
        public double CashBack { get; set; } 
        public double CashBackPcnt { get; set; }
        public double DiscountedPayment { get; set; }

    }
}
