using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSJetClient.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string Department { get; set; }
        public string Destination { get; set; }

        public DateTime Date { get; set; }

        public int Seats { get; set; }
        public double BasePrice { get; set; }
        public bool isComplete { get; set; }
    }
}
