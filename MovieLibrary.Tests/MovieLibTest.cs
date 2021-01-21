using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieLibrary.Models;
using MovieLibrary.Services;

namespace MovieLibrary.Tests
{
    [TestClass]
    public class MovieLibTest
    {
        [TestMethod]
        public async Task MovieListTest()
        {
            var service = new MovieService();
            var result = (await service.GetTopList()).ToList();
            //Lägst först
            Assert.IsFalse(result.First().GetRating() > result.Last().GetRating());
            //Tvärt om
            result = (await service.GetTopList(false)).ToList();
            Assert.IsTrue(result.First().GetRating() > result.Last().GetRating());
        }

        [TestMethod]
        public async Task MovieIdTest()
        {
            var service = new MovieService();
            var result = await service.GetMovieByName("Black Panther");
            Assert.IsTrue(result.GetType() == typeof(IMovieBase));
        }
    }
}