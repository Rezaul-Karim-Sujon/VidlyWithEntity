using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyWithEntity.App_Start;
using VidlyWithEntity.Dtos;
using VidlyWithEntity.Models;

namespace VidlyWithEntity.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        private MapperConfiguration config;
        private IMapper iMapper;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
            config = new AutoMapperConfiguration().Configure();
            iMapper = config.CreateMapper();
        }
        // GET /api/movies
        public IEnumerable<MovieDto> GetMovies(string query = null)
        {
            var movieQuery = _context.Movies
                .Include(m=>m.Genre)
                .Where(m=>m.NumberAvailable>0);
            if (!String.IsNullOrWhiteSpace(query))
                movieQuery = movieQuery
                    .Where(m => m.Name.Contains(query));
            return movieQuery
                .ToList()
                .Select(iMapper.Map<Movie,MovieDto>);
        }

        // GET /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            return Ok(iMapper.Map<Movie, MovieDto>(movie));
        }

        // POST/api/movies
        [HttpPost]
        [Authorize(Roles =RoleName.CanManageMovie)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = iMapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/"+ movie.Id),movieDto);
        }

        // PUT /api/movies/1
        [HttpPut]
        [Authorize(Roles =RoleName.CanManageMovie)]
        public IHttpActionResult UpdateMovie(int id,MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();
            iMapper.Map(movieDto, movieInDb);
            _context.SaveChanges();
            return Ok();
        }

        // DELETE /api/movies/1
        [HttpDelete]
        [Authorize(Roles =RoleName.CanManageMovie)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
