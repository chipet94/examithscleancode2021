using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace MovieLibrary.Models
{
    public class Movie : IMovieBase
    {
        [JsonPropertyName("id")] public string ImdbId { get; set; }
        [JsonPropertyName("rated")] public string ImdbRating { get; set; }
        [JsonPropertyName("title")]public string Title { get; set; }
        public object ViewMe()
        {
            return this;
        }
        public double GetRating()
        {
            return double.Parse(ImdbRating, new NumberFormatInfo{NumberDecimalSeparator = ","});
        }
    }
}