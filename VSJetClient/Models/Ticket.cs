using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSJetClient.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        public double Price { get; set; }

        public int fk_flightId { get; set; }
    }
}
