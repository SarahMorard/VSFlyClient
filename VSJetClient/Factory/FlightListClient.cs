using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSJetClient.Models;


namespace VSJetClient.Factory
{
    public partial class ApiClient
    {
        //Get all flight
        public async Task<List<Flight>> GetFlights()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Flight/"));
            return await GetAsync<List<Flight>>(requestUrl);
        }

        //Get one flight
        public async Task<Flight> GetFlight(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Flight/" + id));
            return await GetAsync<Flight>(requestUrl);
        }


        //Get one booking
        public async Task<Booking> GetBooking(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Booking/" + id));
            return await GetAsync<Booking>(requestUrl);
        }

        //Get one customer by fk
        public async Task<Customer> GetCustomerByFk(int fk)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Customer/" + fk));
            return await GetAsync<Customer>(requestUrl);
        }

        //Get one ticket by fk
        public async Task<Ticket> GetTicketbyFk(int fk)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Ticket/" + fk));
            return await GetAsync<Ticket>(requestUrl);
        }

        //Save one booking
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
    }
}
