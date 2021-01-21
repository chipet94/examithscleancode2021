using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MovieLibrary.Models;
using MovieLibrary.Services.Interfaces;

namespace MovieLibrary.Services
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _client = new();


        public async Task<IEnumerable<IMovieBase>> GetTopList(bool ascending = true)
        {
            var movieList = new List<IMovieBase>();
            var simpleList =
                await ToObjectList<Movie>(
                    await _client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json"));
            var detailedList = await ToObjectList<DetailedMovie>(
                await _client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/detailedMovies.json"));
            var combinedList = (from movie in simpleList
                join detail in detailedList
                    on movie.Title equals detail.Title
                select new CombinedMovie(movie, detail)).ToList();
            
            movieList.AddRange(simpleList);
            movieList.AddRange(detailedList);
            foreach (var movie in combinedList)
            {
                foreach (var existingMovie in movieList.Where(existingMovie => existingMovie.Title == movie.Title))
                {
                    movieList.Remove(existingMovie);
                }
            }
            movieList.AddRange(combinedList);
            return ascending
                ? movieList?.OrderBy(m => m.GetRating())
                : movieList?.OrderByDescending(m => m.GetRating());
        }

        public async Task<IMovieBase> GetMovieByName(string name)
        {
            var movieList = await GetTopList();
            return movieList?.FirstOrDefault(m => m.Title == name);
        }

        private async Task<List<T>> ToObjectList<T>(HttpResponseMessage response)
        {
            using var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
            var result = await reader.ReadToEndAsync();
            return JsonSerializer.Deserialize<List<T>>(result);
        }
    }
}