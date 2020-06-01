using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSJetClient.Models;


namespace VSJetClient.Factory
{
    public partial class ApiClient
    {

        //===========================================GET=============================================================
        //Get all flight
        public async Task<List<Flight>> GetFlights()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Flight/"));
            return await GetAsync<List<Flight>>(requestUrl);
        }

        //Get one flight by its id
        public async Task<Flight> GetFlight(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Flight/" + id));
            return await GetAsync<Flight>(requestUrl);
        }
        //===========================================================================================================


        //===========================================POST============================================================
        //Create one booking
        public async Task<Message<Booking>> SaveBooking(Booking model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Booking/"));
            return await PostAsync<Booking>(requestUrl, model);
        }

        //Create one customer
        public async Task<Message<Customer>> SaveCustomer(Customer model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Customer/"));
            return await PostAsync<Customer>(requestUrl, model);
        }

        //Create one ticket
        public async Task<Message<Ticket>> SaveTicket(Ticket model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Ticket/"));
            return await PostAsync<Ticket>(requestUrl, model);
        }
        //===========================================================================================================
    }
}
