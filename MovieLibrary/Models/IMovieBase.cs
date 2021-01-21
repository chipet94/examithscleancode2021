using System.Text.Json.Serialization;

namespace MovieLibrary.Models
{
    public interface IMovieBase
    {
        public string Title { get; set; }
        object ViewMe();
        public double GetRating();
    }
}