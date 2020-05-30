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

        //PAGE 1
        //Display the form for the booking
        public async Task<IActionResult> DiplayFormBookingAsync(int id)
        {
            //Create a new Ticket 
            Ticket ticket = new Ticket();
            ticket.fk_flightId = id;
            await ApiClientFactory.Instance.SaveTicket(ticket);

            var data = await ApiClientFactory.Instance.GetFlight(id);   

            return View(DiplayBookingAsync(id));
        }

        //PAGE 2
        //Display the informations for the booking of the client
        public async Task<IActionResult> DiplayBookingAsync(int id)
        {
            
            //Manage the viewModel
            BookingViewModel bookingViewModel = new BookingViewModel();

            Flight flight = await ApiClientFactory.Instance.GetFlight(id);
            Customer newCustomer = await ApiClientFactory.Instance.GetCustomerByFk(id);
            Ticket ticket = await ApiClientFactory.Instance.GetTicketbyFk(id);

            Booking booking = new Booking();

            booking.FlighId = bookingViewModel.FlightId;
            booking.CustomerId = bookingViewModel.CustomerId;
            booking.TicketId = bookingViewModel.TicketId;

            await ApiClientFactory.Instance.SaveBooking(booking);

            bookingViewModel.FirstName = newCustomer.FirstName;
            bookingViewModel.LastName = newCustomer.LastName;
            bookingViewModel.FlightId = flight.FlightId;
            bookingViewModel.Department = flight.Department;
            bookingViewModel.Destination = flight.Destination;
            bookingViewModel.Date = flight.Date;
            bookingViewModel.TicketId = ticket.TicketId;
            bookingViewModel.Price = ticket.Price;

            return View(bookingViewModel);
        }

        /*
        //Book the selected flight with the viewModel
        public async Task<IActionResult> ConfirmBookingAsync(BookingViewModel bookingViewModel)
        {

            Booking booking = new Booking();

            booking.FlighId = bookingViewModel.FlightId;
            booking.CustomerId = bookingViewModel.CustomerId;
            booking.TicketId = bookingViewModel.TicketId;

            await ApiClientFactory.Instance.SaveBooking(booking);

            return View();
        }
        */

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}