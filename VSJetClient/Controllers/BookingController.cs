using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using VSJetClient.Factory;
using VSJetClient.Models;
using VSJetClient.Utility;

namespace VSJetClient.Controllers
{
  
    public class BookingController : Controller
    {

        private readonly ILogger<BookingController> _logger;
        private readonly IOptions<MySettingsModel> appSettings;

        public BookingController(ILogger<BookingController> logger, IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
            _logger = logger;
        }

        //Form for the client
        public async Task<IActionResult> Create()
        {
            return View();
        }

        //PAGE 1
        //Display the form for the booking
        public async Task<IActionResult> Create(Customer customer)
        {
            //Post customer
            await ApiClientFactory.Instance.SaveCustomer(customer);

            //Post ticker
            Ticket ticket = new Ticket();
            ticket.fk_flightId = customer.CustomerId;
            await ApiClientFactory.Instance.SaveTicket(ticket);

            //Return general view of the booking
            return View(DiplayBookingAsync(ticket.fk_flightId, ticket, customer));
        }


        //PAGE 2
        //Display the informations for the booking of the client
        public async Task<IActionResult> DiplayBookingAsync(int flightId, Ticket ticket, Customer customer)
        {
            
            //Manage the viewModel
            BookingViewModel bookingViewModel = new BookingViewModel();

            Flight flight = await ApiClientFactory.Instance.GetFlight(flightId);
           
            
            Booking booking = new Booking();

            booking.FlighId = flight.FlightId;
            booking.CustomerId = customer.CustomerId;
            booking.TicketId = ticket.TicketId;

            await ApiClientFactory.Instance.SaveBooking(booking);

            bookingViewModel.FirstName = customer.FirstName;
            bookingViewModel.LastName = customer.LastName;
            bookingViewModel.FlightId = flight.FlightId;
            bookingViewModel.Department = flight.Department;
            bookingViewModel.Destination = flight.Destination;
            bookingViewModel.Date = flight.Date;
            bookingViewModel.TicketId = ticket.TicketId;
            bookingViewModel.Price = ticket.Price;

            return View(bookingViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}