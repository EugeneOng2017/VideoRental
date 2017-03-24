using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoRental.Models;

namespace VideoRental.Controllers.Api
{
    public class RentalsController : ApiController
    {
        ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto rentalDto)
        {
            Customer CustomerInDB = _context.Customers.Single(
                c => c.Id == rentalDto.CustomerId);

            var movies = _context.Movies.Where(
                m => rentalDto.MovieIds.Contains(m.Id));

            DateTime DateRented = DateTime.Now;

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available.");
                }

                movie.NumberAvailable--;

                var Rental = new Rental
                {
                    Customer = CustomerInDB,
                    DateRented = DateRented,
                    Movie = movie
                };

                _context.Rentals.Add(Rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }


}
