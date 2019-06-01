using IMDbReplicaAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDbReplicaAPI.Context
{
    public class IMDbReplicaContext : DbContext
    {
        public IMDbReplicaContext(DbContextOptions<IMDbReplicaContext> options) : base(options)
        {
        }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<MovieActor> MovieActor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieActor>()
            .HasKey(ma => new { ma.MovieId, ma.ActorId });
            modelBuilder.Entity<MovieActor>()
                .HasOne<Movie>(ma => ma.Movie)
                .WithMany(a => a.Actors)
                .HasForeignKey(ma => ma.MovieId);
            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Actor)
                .WithMany(m => m.Movies)
                .HasForeignKey(ma => ma.ActorId);

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 1,
                Title = "Aladin 2019",
                ReleaseDate = new DateTime(2019, 7, 15),
                Rating = 2.4M,
                Description = "It's story about disney aladin.",
                ImageUrl = "../../assets/images/aladin.jpg",
                MovieType = MovieType.Movie
            },
            new Movie
            {
                Id = 2,
                Title = "Godzilla: King of the Monsters(2019)",
                ReleaseDate = new DateTime(2019, 5, 31),
                Rating = 2.5M,
                Description = "It's story about disney aladin.",
                ImageUrl = "../../assets/images/godzila.jpg",
                MovieType = MovieType.Movie
            },
            new Movie
            {
                Id = 3,
                Title = "Rocketman (2019)",
                ReleaseDate = new DateTime(2019, 5, 31),
                Rating = 3.5M,
                Description = "A musical fantasy about the fantastical human story of Elton John's breakthrough years.",
                ImageUrl = "../../assets/images/rocketman.jpg",
                MovieType = MovieType.Movie
            },
            new Movie
            {
                Id = 4,
                Title = "The Shawshank Redemption (1994)",
                ReleaseDate = new DateTime(1994, 1, 12),
                Rating = 4.9M,
                Description = "It's story about prisoners who became good friends and try to escape",
                ImageUrl = "../../assets/images/shawshank.jpg"
            },
            new Movie
            {
                Id = 5,
                Title = "The Godfather (1972)",
                ReleaseDate = new DateTime(1972, 1, 10),
                Rating = 4.9M,
                Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                ImageUrl = "../../assets/images/godfather.jpg",
                MovieType = MovieType.Movie
            },
            new Movie
            {
                Id = 6,
                Title = "The Godfather: Part II (1974)",
                ReleaseDate = new DateTime(1974, 2, 5),
                Rating = 4.8M,
                Description = "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.",
                ImageUrl = "../../assets/images/godfather2.jpg",
                MovieType = MovieType.Movie
            },
            new Movie
            {
                Id = 7,
                Title = "The Dark Knight (2008)",
                ReleaseDate = new DateTime(2008, 9, 24),
                Rating = 4.2M,
                Description = "When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.",
                ImageUrl = "../../assets/images/darknight.jpg",
                MovieType = MovieType.Movie
            },
            new Movie
            {
                Id = 8,
                Title = "12 Angry Men (1957)",
                ReleaseDate = new DateTime(1957, 11, 8),
                Rating = 3.9M,
                Description = "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.",
                ImageUrl = "../../assets/images/angry.jpg",
                MovieType = MovieType.Movie
            },
            new Movie
            {
                Id = 9,
                Title = "Fight Club (1999)",
                ReleaseDate = new DateTime(1999, 9, 15),
                Rating = 3.8M,
                Description = "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.",
                ImageUrl = "../../assets/images/fight.jpg",
                MovieType = MovieType.Movie
            },
            new Movie
            {
                Id = 10,
                Title = "The Lord of the Rings: The Return of the King (2003)",
                ReleaseDate = new DateTime(2003, 5, 11),
                Rating = 3.7M,
                Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                ImageUrl = "../../assets/images/lord.jpg",
                MovieType = MovieType.Movie
            },
            new Movie
            {
                Id = 11,
                Title = "Schindler's List (1993)",
                ReleaseDate = new DateTime(1993, 6, 9),
                Rating = 4.4M,
                Description = "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.",
                ImageUrl = "../../assets/images/schindler.jpg",
                MovieType = MovieType.Movie
            },
            new Movie
            {
                Id = 12,
                Title = "Chernobyl (2019)",
                ReleaseDate = new DateTime(2019, 6, 9),
                Rating = 4.9M,
                Description = "In April 1986, an explosion at the Chernobyl nuclear power plant in the Union of Soviet Socialist Republics becomes one of the world's worst man-made catastrophes.",
                ImageUrl = "../../assets/images/chernobyl.jpg",
                MovieType = MovieType.TvShow
            },
            new Movie
            {
                Id = 13,
                Title = "Planet Earth II (2016)",
                ReleaseDate = new DateTime(2016, 2, 3),
                Rating = 4.7M,
                Description = "David Attenborough returns in this breathtaking documentary showcasing life on Planet Earth.",
                ImageUrl = "../../assets/images/planet.jpg",
                MovieType = MovieType.TvShow
            },
            new Movie
            {
                Id = 14,
                Title = "Band of Brothers (2001)",
                ReleaseDate = new DateTime(2001, 1, 10),
                Rating = 4.8M,
                Description = "The story of Easy Company of the U.S. Army 101st Airborne Division, and their mission in World War II Europe, from Operation Overlord, through V-J Day.",
                ImageUrl = "../../assets/images/band.jpg",
                MovieType = MovieType.TvShow
            },
            new Movie
            {
                Id = 15,
                Title = "Planet Earth (2006)",
                ReleaseDate = new DateTime(2006, 11, 11),
                Rating = 4.6M,
                Description = "Emmy Award-winning, 11 episodes, five years in the making, the most expensive nature documentary series ever commissioned by the BBC, and the first to be filmed in high definition.",
                ImageUrl = "../../assets/images/planet1.jpg",
                MovieType = MovieType.TvShow
            },
            new Movie
            {
                Id = 16,
                Title = "Breaking Bad (2008)",
                ReleaseDate = new DateTime(2008, 8, 17),
                Rating = 4.9M,
                Description = "A high school chemistry teacher diagnosed with inoperable lung cancer turns to manufacturing and selling methamphetamine in order to secure his family's future.",
                ImageUrl = "../../assets/images/bad.jpg",
                MovieType = MovieType.TvShow
            },
            new Movie
            {
                Id = 17,
                Title = "Game of Thrones (2011)",
                ReleaseDate = new DateTime(2011, 5, 5),
                Rating = 5.0M,
                Description = "Nine noble families fight for control over the mythical lands of Westeros, while an ancient enemy returns after being dormant for thousands of years.",
                ImageUrl = "../../assets/images/got.jpg",
                MovieType = MovieType.TvShow
            },
            new Movie
            {
                Id = 18,
                Title = "The Wire (2002)",
                ReleaseDate = new DateTime(2002, 1, 1),
                Rating = 3.7M,
                Description = "Baltimore drug scene, seen through the eyes of drug dealers and law enforcement.",
                ImageUrl = "../../assets/images/wire.jpg",
                MovieType = MovieType.TvShow
            },
            new Movie
            {
                Id = 19,
                Title = "Our Planet (2019)",
                ReleaseDate = new DateTime(2019, 10, 15),
                Rating = 3.5M,
                Description = "Documentary series focusing on the breadth of the diversity of habitats around the world, from the remote Arctic wilderness and mysterious deep oceans to the vast landscapes of Africa and diverse jungles of South America.",
                ImageUrl = "../../assets/images/our.jpg",
                MovieType = MovieType.TvShow
            },
            new Movie
            {
                Id = 20,
                Title = "Cosmos (2014)",
                ReleaseDate = new DateTime(2014, 3, 10),
                Rating = 3.1M,
                Description = "An exploration of our discovery of the laws of nature and coordinates in space and time.",
                ImageUrl = "../../assets/images/cosmos.jpg",
                MovieType = MovieType.TvShow
            },
            new Movie
            {
                Id = 21,
                Title = "Blue Planet II (2017)",
                ReleaseDate = new DateTime(2017, 11, 11),
                Rating = 3.3M,
                Description = "David Attenborough returns to the world's oceans in this sequel to the acclaimed documentary filming rare and unusual creatures of the deep, as well as documenting the problems our oceans face.",
                ImageUrl = "../../assets/images/blue.jpg",
                MovieType = MovieType.TvShow
            },
            new Movie
            {
                Id = 22,
                Title = "Rick and Morty (2013)",
                ReleaseDate = new DateTime(2013, 6, 9),
                Rating = 2.9M,
                Description = "An animated series that follows the exploits of a super scientist and his not-so-bright grandson.",
                ImageUrl = "../../assets/images/rick.jpg",
                MovieType = MovieType.TvShow
            }
            );

            modelBuilder.Entity<Actor>().HasData(new Actor { Id = 1, Name = "Steven Seagal" },
                new Actor { Id = 2, Name = "Jan Claude Van Damme" }, new Actor { Id = 3, Name = "Ian Mcgregor" },
                new Actor { Id = 4, Name = "Brad Pitt" }, new Actor { Id = 5, Name = "Leonardo Di Caprio" }
            );

            modelBuilder.Entity<MovieActor>().HasData(
                new MovieActor { MovieId = 1, ActorId = 1 }, new MovieActor { MovieId = 1, ActorId = 2 }, new MovieActor { MovieId = 1, ActorId = 3 }, new MovieActor { MovieId = 1, ActorId = 4 },
                new MovieActor { MovieId = 2, ActorId = 1 }, new MovieActor { MovieId = 2, ActorId = 2 }, new MovieActor { MovieId = 2, ActorId = 5 },
                new MovieActor { MovieId = 3, ActorId = 3 }, new MovieActor { MovieId = 3, ActorId = 5 }, 
                new MovieActor { MovieId = 4, ActorId = 4 }, new MovieActor { MovieId = 4, ActorId = 5 }, new MovieActor { MovieId = 4, ActorId = 2 }, new MovieActor { MovieId = 4, ActorId = 1 },
                new MovieActor { MovieId = 5, ActorId = 2 }, new MovieActor { MovieId = 5, ActorId = 5 }, new MovieActor { MovieId = 5, ActorId = 3 },
                new MovieActor { MovieId = 6, ActorId = 4 }, new MovieActor { MovieId = 6, ActorId = 5 }, new MovieActor { MovieId = 6, ActorId = 2 }, new MovieActor { MovieId = 6, ActorId = 3 },
                new MovieActor { MovieId = 7, ActorId = 4 }, new MovieActor { MovieId = 7, ActorId = 5 }, new MovieActor { MovieId = 7, ActorId = 3 }, new MovieActor { MovieId = 7, ActorId = 1 },
                new MovieActor { MovieId = 8, ActorId = 4 }, new MovieActor { MovieId = 8, ActorId = 5 }, new MovieActor { MovieId = 8, ActorId = 2 }, new MovieActor { MovieId = 8, ActorId = 3 },
                new MovieActor { MovieId = 9, ActorId = 4 }, new MovieActor { MovieId = 9, ActorId = 5 }, new MovieActor { MovieId = 9, ActorId = 3 }, new MovieActor { MovieId = 9, ActorId = 1 },
                new MovieActor { MovieId = 10, ActorId = 4 }, new MovieActor { MovieId = 10, ActorId = 5 }, new MovieActor { MovieId = 10, ActorId = 2 }, new MovieActor { MovieId = 10, ActorId = 1 },
                new MovieActor { MovieId = 11, ActorId = 4 }, new MovieActor { MovieId = 11, ActorId = 5 }, new MovieActor { MovieId = 11, ActorId = 2 }, new MovieActor { MovieId = 11, ActorId = 3 }
                );

        }
    }
}




