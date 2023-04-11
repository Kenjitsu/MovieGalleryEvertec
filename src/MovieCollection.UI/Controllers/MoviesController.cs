using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MovieCollection.Core.Interfaces.Services;
using MovieCollection.UI.Models;

namespace MovieCollection.UI.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IOMDbMoviesService _omdbMoviesService;

        public MoviesController(IOMDbMoviesService omdbMoviesService)
        {
            _omdbMoviesService = omdbMoviesService ?? throw new ArgumentNullException(nameof(omdbMoviesService));
        }

        public async Task<IActionResult> Index(string movieName = "batman", int page = 1)
        {
            var moviesViewModel = new MoviesViewModel
            {
                MovieName = movieName,
                Page = page
            };

            // Validar si el nombre de la película está vacío.
            if (movieName != null)
            {
                // Para que no falle la consulta.
                if (moviesViewModel.Page <= 0) moviesViewModel.Page = 1;
                moviesViewModel.Movies = await _omdbMoviesService.GetMoviesByName(moviesViewModel.MovieName, moviesViewModel.Page);
                return View(moviesViewModel);
            }

            moviesViewModel.Movies = await _omdbMoviesService.GetMoviesByName();
            return View(moviesViewModel);

        }
    }

    
}
