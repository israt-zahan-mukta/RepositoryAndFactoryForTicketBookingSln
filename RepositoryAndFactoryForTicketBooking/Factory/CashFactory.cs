using RepositoryAndFactoryForTicketBooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndFactoryForTicketBooking.Factory
{
    public class CashFactory : PassengerFactory
    {
        public CashFactory(Passenger passenger) : base(passenger)
        {
        }

        public override IPassengerManager Create()
        {
            return new CashPaymentManager();
        }
    }
}
