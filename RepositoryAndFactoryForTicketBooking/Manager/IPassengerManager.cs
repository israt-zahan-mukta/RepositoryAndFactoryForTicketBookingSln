using RepositoryAndFactoryForTicketBooking.Entities;

namespace RepositoryAndFactoryForTicketBooking.Factory
{
    public interface IPassengerManager
    {
        double GetCashBack(Passenger pan);
        double GetDiscountedPayment(Passenger pan);
        double GetTotalPayment(Passenger passenger);
    }
}