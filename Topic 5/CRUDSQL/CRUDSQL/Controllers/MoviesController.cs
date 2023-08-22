using Act_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Act_2.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            HardCodedMoviesSampleDataRepository repository = new HardCodedMoviesSampleDataRepository();
            return View(repository.AllMovies());
        }
    }
}
