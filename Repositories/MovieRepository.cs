using IMDbReplicaAPI.Context;
using IMDbReplicaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDbReplicaAPI.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IMDbReplicaContext _context;

        public MovieRepository(IMDbReplicaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAllMovies(int numberOfItemsToTake, int movieType)
        {
            List<Movie> movies = new List<Movie>();
            switch (movieType)
            {
                case 0: movies = await _context.Movie.Where(x => x.MovieType == MovieType.Movie).Include(x => x.Actors).ThenInclude(y => y.Actor).OrderByDescending(o => o.Rating).Take(numberOfItemsToTake).ToListAsync();
                    break;
                case 1: movies = await _context.Movie.Where(x => x.MovieType == MovieType.TvShow).Include(x => x.Actors).ThenInclude(y => y.Actor).OrderByDescending(o => o.Rating).Take(numberOfItemsToTake).ToListAsync();
                    break;
                default:
                    break;
            }

            foreach (var movie in movies)
            {
                foreach (var actor in movie.Actors)
                {
                    if (actor.MovieId == movie.Id)
                    {
                        movie.Cast.Add(actor.Actor.Name);
                    }
                }
                movie.Actors = null;
            }

            return movies;
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var movie = await _context.Movie.Where(x => x.Id == id).FirstOrDefaultAsync();
            return movie;
        }

        public async Task RateMovie(int rating, int movieId)
        {
            var ratingHistory = await _context.RatingHistory.Where(x => x.MovieId == movieId).FirstOrDefaultAsync();
            ratingHistory.TotalNumberOfVotes++;
            ratingHistory.TotalVotesRating += rating;
            var movie = await GetMovieById(movieId);
            if(movie != null)
            {
                movie.Rating = (decimal)ratingHistory.TotalVotesRating / ratingHistory.TotalNumberOfVotes;
            }
            _context.Update(ratingHistory);
            _context.Update(movie);
            await _context.SaveChangesAsync();
        }
    }
}
