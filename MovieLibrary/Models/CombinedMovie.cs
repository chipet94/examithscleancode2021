using System;
using System.Collections.Generic;

namespace MovieLibrary.Models
{
    public class CombinedMovie : IMovieBase
    
    
    {
        public CombinedMovie(Movie movie, DetailedMovie detailedMovie)
        {
            Id = detailedMovie.Id;
            ImdbId = movie.ImdbId;
            OriginalTitle = movie.Title;
            AvrageRating = movie.ImdbRating;
            Year = detailedMovie.Year;
            Genres = detailedMovie.Genres;
            Ratings = detailedMovie.Ratings;
            Poster = detailedMovie.Poster;
            ContentRating = detailedMovie.ContentRating;
            Duration = detailedMovie.Duration;
            ReleaseDate = detailedMovie.ReleaseDate;
            Storyline = detailedMovie.Storyline;
            Actors = detailedMovie.Actors;
            ImdbRating = detailedMovie.ImdbRating;
            PosterUrl = detailedMovie.PosterUrl;
        }

        public string Id { get; set; }
        public string ImdbId { get; set; }
        public string Year { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public IEnumerable<int> Ratings { get; set; }
        public string Poster { get; set; }
        public string ContentRating { get; set; }
        public string Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string AvrageRating { get; set; }
        public string OriginalTitle { get; set; }
        public string Storyline { get; set; }
        public IEnumerable<string> Actors { get; set; }
        public double ImdbRating { get; set; }
        public string PosterUrl { get; set; }
        public string Title { get; set; }

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