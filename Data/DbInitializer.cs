using FilmVault.Models;

namespace FilmVault.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MovieContext context)
        {
            if (context.Movies.Any() && context.Directors.Any() && context.Genres.Any())
            {
                return;   // DB has been seeded
            }

            var actionGenre = new Genre { Name = "Action" };
            var dramaGenre = new Genre { Name = "Drama" };
            var comedyGenre = new Genre { Name = "Comedy" };
            var sciFiGenre = new Genre { Name = "Sci-Fi" };
            var thrillerGenre = new Genre { Name = "Thriller" };

            var nolanDirector = new Director { Name = "Christopher Nolan", IsAwardWinner = true };
            var tarantinoDirector = new Director { Name = "Quentin Tarantino", IsAwardWinner = true };
            var spielbergDirector = new Director { Name = "Steven Spielberg", IsAwardWinner = true };

            var movies = new Movie[]
            {
                new Movie
                {
                    Title = "Inception",
                    Director = nolanDirector,
                    Genres = new List<Genre>
                    {
                        actionGenre,
                        sciFiGenre,
                        thrillerGenre
                    },
                    IsAvailableIn4K = true
                },
                new Movie
                {
                    Title = "Pulp Fiction",
                    Director = tarantinoDirector,
                    Genres = new List<Genre>
                    {
                        dramaGenre,
                        thrillerGenre
                    },
                    IsAvailableIn4K = false
                },
                new Movie
                {
                    Title = "Jurassic Park",
                    Director = spielbergDirector,
                    Genres = new List<Genre>
                    {
                        actionGenre,
                        sciFiGenre
                    },
                    IsAvailableIn4K = true
                }
            };

            context.Movies.AddRange(movies);
            context.SaveChanges();
        }
    }
}
