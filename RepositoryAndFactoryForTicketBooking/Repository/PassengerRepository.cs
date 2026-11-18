using RepositoryAndFactoryForTicketBooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndFactoryForTicketBooking.Repository
{
    public class PassengerRepository : IPassengerRepository
    {
        private List <Passenger> db ;
        public PassengerRepository()
        {
            db = new List<Passenger>()
            {
                new Passenger(){PassengerID = 1, Name = "Megh", Email = "megh@gmail.com" , Type = SeatType.FirstClass , Pay = Payment.Cash, FirstClassPrice = 45000.00, EconomyPrice = 0, NoOfSeat = 2, TotalPayment = 90000.00, CashBack = 13500.00, DiscountedPayment = 76500},
                new Passenger(){PassengerID = 2, Name = "Mahi", Email = "mahi@gmail.com" , Type = SeatType.Economy , Pay = Payment.Card, FirstClassPrice = 0, EconomyPrice = 30000, NoOfSeat = 3, TotalPayment = 90000, CashBack = 0, DiscountedPayment = 0}
            };

        }


        public IEnumerable<Passenger> GetPassengerList()
        {
            return db;
        }

        public Passenger GetPassengerById(int id)
        {
            return db.FirstOrDefault(p => p.PassengerID == id);
        }
        public void DeletePassenger(int id)
        {
            Passenger pag = GetPassengerById(id);
            if (pag != null)
            {
                db.Remove(pag);
            }
            pag = GetPassengerById(id);
            if (pag != null)
            {
                db.Remove(pag);
            }
            pag = GetPassengerById(id);
            if (pag != null)
            {
                db.Remove(pag);
            }
        }

        public void SavePassenger(Passenger pag)
        {
            pag.PassengerID = db.Count > 0 ? db.Max(p => p.PassengerID) + 1 : 1;
            db.Add(pag);
        }

        public void UpdatePassenger(Passenger upPag)
        {
            Passenger exPag = GetPassengerById(upPag.PassengerID);
            if (exPag != null)
            {
                exPag.Name = upPag.Name;
                exPag.Email = upPag.Email;
                exPag.Type = upPag.Type;
                exPag.Pay = upPag.Pay;
                exPag.FirstClassPrice = upPag.FirstClassPrice;
                exPag.EconomyPrice = upPag.EconomyPrice;
                exPag.NoOfSeat = upPag.NoOfSeat;
            }
        }
    }
}
