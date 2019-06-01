using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDbReplicaAPI.Models;
using IMDbReplicaAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMDbReplicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }

        [HttpGet("{numberOfItemsToTake}/{movieType}")]
        public async Task<ActionResult<List<Movie>>> Get(int numberOfItemsToTake, int movieType)
        {
            var movies = await _service.GetAllMovies(numberOfItemsToTake, movieType);
            return Ok(movies);
        }

        [HttpPatch]
        [Authorize]
        public async Task RateMovie([FromBody]int rating, [FromBody]Movie movie)
        {
            await _service.RateMovie(rating, movie);
        }
    }
}