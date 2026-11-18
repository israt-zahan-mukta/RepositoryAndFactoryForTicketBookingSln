using RepositoryAndFactoryForTicketBooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndFactoryForTicketBooking.Factory
{
    public abstract class PassengerFactory
    {
        protected Passenger passenger;
        protected PassengerFactory(Passenger pan)
        {
            passenger = pan;
        }

        public abstract IPassengerManager Create();

        public Passenger ProcessPassenger()
        {
            IPassengerManager manager = Create();
            passenger.CashBack = manager.GetCashBack(passenger);
            passenger.DiscountedPayment = manager.GetDiscountedPayment(passenger);
            passenger.TotalPayment = manager.GetTotalPayment(passenger);
            return passenger;
        }
    }
}
