using MovieCollection.Core.DTOs;

namespace MovieCollection.Core.Interfaces.Services;

public interface IOMDbMoviesService
{
    Task<ResponseDTO> GetMoviesByName(string? movieName = null, int page = 1);
}
