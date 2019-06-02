using IMDbReplicaAPI.Models;
using IMDbReplicaAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDbReplicaAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Movie>> GetAllMovies(int numberOfItemsToTake, int movieType)
        {
            return await _repository.GetAllMovies(numberOfItemsToTake, movieType);
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _repository.GetMovieById(id);
        }

        public async Task RateMovie(int rating, int movieId)
        {
            await _repository.RateMovie(rating, movieId);
        }
    }
}
