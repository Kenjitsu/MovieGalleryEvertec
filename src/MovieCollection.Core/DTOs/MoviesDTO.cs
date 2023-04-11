namespace MovieCollection.Core.DTOs;

public class MoviesDTO
{
    public string Title { get; set; } = string.Empty;
    public string Year { get; set; } = string.Empty;
    public string imdbID { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string? Poster { get; set; }
}
