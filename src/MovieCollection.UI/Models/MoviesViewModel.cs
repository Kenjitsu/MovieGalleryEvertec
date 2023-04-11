using MovieCollection.Core.DTOs;

namespace MovieCollection.UI.Models;

public class MoviesViewModel
{
    public ResponseDTO? Movies { get; set; }
    public int Page { get; set; }
    public string? MovieName { get; set; }
}
