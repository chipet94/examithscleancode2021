using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MovieLibrary.Models
{
    public class DetailedMovie : IMovieBase
    {
        [JsonPropertyName("id")] public string Id { get; set; }
        
        [JsonPropertyName("year")] public string Year { get; set; }

        [JsonPropertyName("genres")] public IEnumerable<string> Genres { get; set; }

        [JsonPropertyName("ratings")] public IEnumerable<int> Ratings { get; set; }

        [JsonPropertyName("poster")] public string Poster { get; set; }

        [JsonPropertyName("contentRating")] public string ContentRating { get; set; }

        [JsonPropertyName("duration")] public string Duration { get; set; }

        [JsonPropertyName("releaseDate")] public DateTime ReleaseDate { get; set; }

        [JsonPropertyName("storyline")] public string Storyline { get; set; }

        [JsonPropertyName("actors")] public IEnumerable<string> Actors { get; set; }

        [JsonPropertyName("imdbRating")] public double ImdbRating { get; set; }

        [JsonPropertyName("posterurl")] public string PosterUrl { get; set; }
        [JsonPropertyName("title")]public string Title { get; set; }
        public object ViewMe()
        {
            return this;
        }
        public double GetRating()
        {
            return ImdbRating;
        }
    }
}