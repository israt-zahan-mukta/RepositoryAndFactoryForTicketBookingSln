using RepositoryAndFactoryForTicketBooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndFactoryForTicketBooking.Factory
{
    public class CardFactory : PassengerFactory
    {
        public CardFactory(Passenger passenger) : base(passenger) {}

        public override IPassengerManager Create()
        {
            return new CardPaymentManager();
        }
    }
}
