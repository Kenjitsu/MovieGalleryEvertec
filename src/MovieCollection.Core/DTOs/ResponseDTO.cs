namespace MovieCollection.Core.DTOs;

public class ResponseDTO
{
    public List<MoviesDTO>? Search { get; set; }
    public string? totalResults { get; set; }
    public string? Response { get; set; }
}
