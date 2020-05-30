using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSJetClient.Models
{
    public class BookingViewModel
    {
        //Customer
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //FLight
        public int FlightId { get; set; }
        public string Department { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }

        //Ticket
        public int TicketId { get; set; }
        public double Price { get; set; }

    }
}
