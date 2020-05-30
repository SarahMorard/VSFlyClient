using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSJetClient.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int FlighId { get; set; }
        public int CustomerId { get; set; }
        public int TicketId { get; set; }
    }
}
