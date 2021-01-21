using System.Collections.Generic;
using System.Threading.Tasks;
using MovieLibrary.Models;

namespace MovieLibrary.Services.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<IMovieBase>> GetTopList(bool ascending);
        Task<IMovieBase> GetMovieByName(string id);

    }
}