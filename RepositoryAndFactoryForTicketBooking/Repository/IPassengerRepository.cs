using RepositoryAndFactoryForTicketBooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndFactoryForTicketBooking.Repository
{
    public interface IPassengerRepository
    {
        void SavePassenger(Passenger passenger);
        IEnumerable<Passenger> GetPassengerList();
        Passenger GetPassengerById(int id);
        void UpdatePassenger(Passenger passenger);
        void DeletePassenger(int id);
    }
}
