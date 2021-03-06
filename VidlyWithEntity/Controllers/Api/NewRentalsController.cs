using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyWithEntity.Dtos;
using VidlyWithEntity.Models;

namespace VidlyWithEntity.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);
            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id));     // SQL statement    SELECT * FROM Movies WHERE Id In(1,2,3)
            foreach(var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");
                movie.NumberAvailable--;
                var rental = new Rental 
                {
                    Customer=customer,
                    Movie=movie,
                    DateRented=DateTime.Now
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
