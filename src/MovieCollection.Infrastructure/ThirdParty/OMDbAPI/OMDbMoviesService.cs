using Microsoft.Extensions.Configuration;
using MovieCollection.Core.DTOs;
using MovieCollection.Core.Interfaces.Services;
using RestSharp;
using System.Text.Json;

namespace MovieCollection.Infrastructure.ThirdParty.OMDbAPI;

public class OMDbMoviesService : IOMDbMoviesService
{
    private readonly string _OMDbUrl;
    private readonly string _OMDbApiKey;
    public OMDbMoviesService(IConfiguration configuration)
    {
        _OMDbUrl = configuration.GetSection("OMDbAPI:BaseUrl").Value!;
        _OMDbApiKey = configuration.GetSection("OMDbAPI:ApiKey").Value!;
    }

    /// <summary>
    /// Método para hacer el consumo del API de OMDb.
    /// </summary>
    /// <param name="movieName">nombre de la pelicula.</param>
    /// <param name="page">página a buscar.</param>
    /// <returns>Objeto ResponseDTO con la respuesta del API.</returns>
    public async Task<ResponseDTO> GetMoviesByName(string? movieName, int page)
    {
        var movieNameValidated = ValidateMovieNameFormat(movieName);

        var client = new RestClient(_OMDbUrl);

        var request = new RestRequest()
            .AddParameter("apikey", _OMDbApiKey)
            .AddParameter("s", movieNameValidated)
            .AddParameter("type", "movie")
            .AddParameter("page", $"{page}");

        RestResponse response = await client.GetAsync(request);
        ResponseDTO requestResponse = JsonSerializer.Deserialize<ResponseDTO>(response.Content);

        return requestResponse;
         
    }

    /// <summary>
    /// Validar si la cadena contiene espacios.
    /// </summary>
    /// <param name="movieName">Nombre de la pelicula</param>
    /// <returns>cadena con el formato adecuado para el query en la url.</returns>
    private string ValidateMovieNameFormat(string movieName)
    {
        if (movieName == null) return "batman";
        return movieName.Contains(" ") ? movieName.Replace(" ", "+") : movieName;
    }
}
