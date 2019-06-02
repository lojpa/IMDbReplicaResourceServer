using IMDbReplicaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDbReplicaAPI.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllMovies(int numberOfItemsToTake, int movieType);
        Task<Movie> GetMovieById(int id);
        Task RateMovie(int rating, int movieId);
    }
}
