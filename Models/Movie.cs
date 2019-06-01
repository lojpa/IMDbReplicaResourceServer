using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IMDbReplicaAPI.Models
{
    public enum MovieType
    {
        Movie,
        TvShow
    }

    public class Movie
    {
        public Movie()
        {
            Cast = new List<string>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public List<MovieActor> Actors { get; set; }

        public decimal Rating { get; set; }

        public MovieType MovieType { get; set; }

        [NotMapped]
        public List<string> Cast { get; set; }
    }
}
