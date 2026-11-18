using RepositoryAndFactoryForTicketBooking.Entities;

namespace RepositoryAndFactoryForTicketBooking.Factory
{
    internal class CashPaymentManager : IPassengerManager
    {
        public double GetCashBack(Passenger pan)
        {
            return GetTotalPayment(pan) * pan.CashBackPcnt;
        }

        public double GetDiscountedPayment(Passenger pan)
        {
            return GetTotalPayment(pan)-GetCashBack(pan);
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