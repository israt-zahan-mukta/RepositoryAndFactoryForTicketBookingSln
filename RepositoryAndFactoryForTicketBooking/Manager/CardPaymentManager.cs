using RepositoryAndFactoryForTicketBooking.Entities;
using System;

namespace RepositoryAndFactoryForTicketBooking.Factory
{
    internal class CardPaymentManager : IPassengerManager
    {
        public double GetCashBack(Passenger pan)
        {
            return 0;
        }

        public double GetDiscountedPayment(Passenger pan)
        {
            return 0;
        }

        public double GetTotalPayment(Passenger pan)
        {
            double discountedPayment = 0;
            if (pan.Type == SeatType.FirstClass)
            {
                discountedPayment = pan.FirstClassPrice * pan.NoOfSeat;
            }
            else if (pan.Type == SeatType.Economy)
            {
                discountedPayment = pan.EconomyPrice * pan.NoOfSeat;
            }
            return discountedPayment;
        }
    }
}