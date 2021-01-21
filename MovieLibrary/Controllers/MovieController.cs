using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Models;
using MovieLibrary.Services.Interfaces;

namespace MovieLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("/toplist")]
        public async Task<IEnumerable<object>> TopList(bool asc = true)
        {
            return (await _service.GetTopList(asc)).Select(x => x.ViewMe()).ToList();
        }

        [HttpGet]
        [Route("/movie")]
        public async Task<IActionResult> GetMovieById(string name)
        {
            var movie = await _service.GetMovieByName(name);
            if (movie == null) return BadRequest("Found no movie with that ID.");
            return Ok(movie);
        }
    }
}