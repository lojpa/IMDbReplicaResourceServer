using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IMDbReplicaAPI.Models
{
    public class RatingHistory
    {
        public int Id { get; set; }

        public int TotalNumberOfVotes { get; set; }

        public int TotalVotesRating { get; set; }

        public int MovieId { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
    }
}
