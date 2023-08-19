using Act_2.Models;
using Bogus;

namespace Act_2.Services
{
    public class HardCodedMoviesSampleDataRepository : IMoviesDataService
    {
        List<MovieModel> movieList = new List<MovieModel>();

        public HardCodedMoviesSampleDataRepository()
        {
            movieList.Add(new MovieModel(1,"Shrek", 12.99m, new DateTime(2023, 12, 31)));

            for (int i = 0; i < 10; i++)
            {
                movieList.Add(new Faker<MovieModel>()
                    .RuleFor(p => p.Id, i + 5)
                    .RuleFor(p => p.Title, f => f.Company.CatchPhrase())
                    .RuleFor(p => p.Price, f => f.Random.Decimal(100))
                    .RuleFor(p => p.AirDate, f => f.Date.Recent(0))
                    );
            }
        }

        public List<MovieModel> AllMovies()
        {
            return movieList;
        }
    }
}
