using IMDbReplicaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDbReplicaAPI.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMovies(int numberOfItemsToTake, int movieType);
        Task RateMovie(int rating, Movie movie);
    }
}
