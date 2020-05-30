using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSJetClient.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int fk_ticketId { get; set; }
    }
}
