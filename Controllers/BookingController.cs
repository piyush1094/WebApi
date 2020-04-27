using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class BookingController : ApiController
    {
        private readonly CampDbContext context;
        public BookingController()
        {
            context = new CampDbContext();
        }

        [HttpGet]
        public IEnumerable<Booking> Getbookings()
        {
            return context.bookings.ToList();
        }
        [HttpPost]
        public Booking Postbookings(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            context.bookings.Add(booking);
            context.SaveChanges();

            return booking;
        }
    }
}
