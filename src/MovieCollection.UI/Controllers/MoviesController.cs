using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MovieCollection.Core.Interfaces.Services;
using MovieCollection.UI.Models;

namespace MovieCollection.UI.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IOMDbMoviesService _omdbMoviesService;
        private readonly IMemoryCache _cache;

        public MoviesController(IOMDbMoviesService omdbMoviesService, IMemoryCache cache)
        {
            _omdbMoviesService = omdbMoviesService ?? throw new ArgumentNullException(nameof(omdbMoviesService));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task<IActionResult> Index(string movieName = "batman", int page = 1)
        {
            var model = new MoviesViewModel
            {
                MovieName = movieName,
                Page = page
            };

            // Validar si el nombre de la película está vacío.
            if (movieName != null)
            {
                model.Movies = await _omdbMoviesService.GetMoviesByName(model.MovieName, model.Page);
                return View(model);
            }

            model.Movies = await _omdbMoviesService.GetMoviesByName();
            return View(model);

        }
    }

    
}
