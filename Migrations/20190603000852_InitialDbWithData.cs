using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IMDbReplicaAPI.Migrations
{
    public partial class InitialDbWithData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Rating = table.Column<decimal>(nullable: false),
                    MovieType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieActor",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    ActorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActor", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_MovieActor_Actor_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActor_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RatingHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TotalNumberOfVotes = table.Column<int>(nullable: false),
                    TotalVotesRating = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RatingHistory_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Steven Seagal" },
                    { 2, "Jan Claude Van Damme" },
                    { 3, "Ian Mcgregor" },
                    { 4, "Brad Pitt" },
                    { 5, "Leonardo Di Caprio" }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Description", "ImageUrl", "MovieType", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 20, "An exploration of our discovery of the laws of nature and coordinates in space and time.", "../../assets/images/cosmos.jpg", 1, 3.1m, new DateTime(2014, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cosmos (2014)" },
                    { 19, "Documentary series focusing on the breadth of the diversity of habitats around the world, from the remote Arctic wilderness and mysterious deep oceans to the vast landscapes of Africa and diverse jungles of South America.", "../../assets/images/our.jpg", 1, 3.5m, new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Our Planet (2019)" },
                    { 18, "Baltimore drug scene, seen through the eyes of drug dealers and law enforcement.", "../../assets/images/wire.jpg", 1, 3.7m, new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Wire (2002)" },
                    { 17, "Nine noble families fight for control over the mythical lands of Westeros, while an ancient enemy returns after being dormant for thousands of years.", "../../assets/images/got.jpg", 1, 5.0m, new DateTime(2011, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Game of Thrones (2011)" },
                    { 16, "A high school chemistry teacher diagnosed with inoperable lung cancer turns to manufacturing and selling methamphetamine in order to secure his family's future.", "../../assets/images/bad.jpg", 1, 4.9m, new DateTime(2008, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Breaking Bad (2008)" },
                    { 15, "Emmy Award-winning, 11 episodes, five years in the making, the most expensive nature documentary series ever commissioned by the BBC, and the first to be filmed in high definition.", "../../assets/images/planet1.jpg", 1, 4.6m, new DateTime(2006, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Planet Earth (2006)" },
                    { 14, "The story of Easy Company of the U.S. Army 101st Airborne Division, and their mission in World War II Europe, from Operation Overlord, through V-J Day.", "../../assets/images/band.jpg", 1, 4.8m, new DateTime(2001, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Band of Brothers (2001)" },
                    { 13, "David Attenborough returns in this breathtaking documentary showcasing life on Planet Earth.", "../../assets/images/planet.jpg", 1, 4.7m, new DateTime(2016, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Planet Earth II (2016)" },
                    { 12, "In April 1986, an explosion at the Chernobyl nuclear power plant in the Union of Soviet Socialist Republics becomes one of the world's worst man-made catastrophes.", "../../assets/images/chernobyl.jpg", 1, 4.9m, new DateTime(2019, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chernobyl (2019)" },
                    { 11, "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "../../assets/images/schindler.jpg", 0, 4.4m, new DateTime(1993, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schindler's List (1993)" },
                    { 9, "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.", "../../assets/images/fight.jpg", 0, 3.8m, new DateTime(1999, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fight Club (1999)" },
                    { 21, "David Attenborough returns to the world's oceans in this sequel to the acclaimed documentary filming rare and unusual creatures of the deep, as well as documenting the problems our oceans face.", "../../assets/images/blue.jpg", 1, 3.3m, new DateTime(2017, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blue Planet II (2017)" },
                    { 8, "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.", "../../assets/images/angry.jpg", 0, 3.9m, new DateTime(1957, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "12 Angry Men (1957)" },
                    { 7, "When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.", "../../assets/images/darknight.jpg", 0, 4.2m, new DateTime(2008, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight (2008)" },
                    { 6, "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.", "../../assets/images/godfather2.jpg", 0, 4.8m, new DateTime(1974, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather: Part II (1974)" },
                    { 5, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "../../assets/images/godfather.jpg", 0, 4.9m, new DateTime(1972, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather (1972)" },
                    { 4, "It's story about prisoners who became good friends and try to escape", "../../assets/images/shawshank.jpg", 0, 4.9m, new DateTime(1994, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption (1994)" },
                    { 3, "A musical fantasy about the fantastical human story of Elton John's breakthrough years.", "../../assets/images/rocketman.jpg", 0, 3.5m, new DateTime(2019, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rocketman (2019)" },
                    { 2, "It's story about disney aladin.", "../../assets/images/godzila.jpg", 0, 2.5m, new DateTime(2019, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Godzilla: King of the Monsters(2019)" },
                    { 1, "It's story about disney aladin.", "../../assets/images/aladin.jpg", 0, 2.4m, new DateTime(2019, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aladin 2019" },
                    { 10, "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.", "../../assets/images/lord.jpg", 0, 3.7m, new DateTime(2003, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Return of the King (2003)" },
                    { 22, "An animated series that follows the exploits of a super scientist and his not-so-bright grandson.", "../../assets/images/rick.jpg", 1, 2.9m, new DateTime(2013, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rick and Morty (2013)" }
                });

            migrationBuilder.InsertData(
                table: "MovieActor",
                columns: new[] { "MovieId", "ActorId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 11, 2 },
                    { 7, 4 },
                    { 7, 5 },
                    { 7, 3 },
                    { 7, 1 },
                    { 8, 4 },
                    { 8, 5 },
                    { 8, 2 },
                    { 8, 3 },
                    { 9, 4 },
                    { 9, 5 },
                    { 9, 3 },
                    { 9, 1 },
                    { 10, 4 },
                    { 10, 5 },
                    { 10, 2 },
                    { 10, 1 },
                    { 11, 4 },
                    { 11, 5 },
                    { 6, 2 },
                    { 6, 5 },
                    { 6, 3 },
                    { 3, 5 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 5 },
                    { 3, 3 },
                    { 6, 4 },
                    { 4, 4 },
                    { 11, 3 },
                    { 4, 2 },
                    { 4, 1 },
                    { 5, 2 },
                    { 5, 5 },
                    { 5, 3 },
                    { 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "RatingHistory",
                columns: new[] { "Id", "MovieId", "TotalNumberOfVotes", "TotalVotesRating" },
                values: new object[,]
                {
                    { 18, 18, 100, 370 },
                    { 13, 13, 100, 470 },
                    { 14, 14, 100, 480 },
                    { 19, 19, 100, 350 },
                    { 12, 12, 100, 490 },
                    { 17, 17, 100, 500 },
                    { 20, 20, 100, 310 },
                    { 11, 11, 100, 440 },
                    { 15, 15, 100, 460 },
                    { 16, 16, 100, 490 },
                    { 7, 7, 100, 420 },
                    { 9, 9, 100, 380 },
                    { 8, 8, 100, 390 },
                    { 21, 21, 100, 330 },
                    { 6, 6, 100, 480 },
                    { 5, 5, 100, 490 },
                    { 4, 4, 100, 490 },
                    { 3, 3, 100, 350 },
                    { 2, 2, 100, 250 },
                    { 1, 1, 100, 240 },
                    { 10, 10, 100, 370 },
                    { 22, 22, 100, 290 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActor_ActorId",
                table: "MovieActor",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_RatingHistory_MovieId",
                table: "RatingHistory",
                column: "MovieId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActor");

            migrationBuilder.DropTable(
                name: "RatingHistory");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
