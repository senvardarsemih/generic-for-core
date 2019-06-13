using Moq;
using PatternForCore.Models.Common;
using PatternForCore.Services.Base.Contracts;
using Shouldly;
using Xunit;

namespace PatternForCore.Tests
{
    public class MovieServiceTest
    {
        [Fact]
        public void Create_Movie_Calls_MovieServiceAdd()
        {
            var movie = new Movie
            {
                Title = "Test Movie",
                Director = "Test Director",
                Genre = "Test Genre",
                Year = 2018,
                Comments = "Test",
                OriginalTitle = "Original Test"
            };

            var mockMovieService = new Mock<IMovieServices>();
            mockMovieService.Setup(x => x.AddMovie(movie)).Returns(true);
            mockMovieService.Object.AddMovie(movie).ShouldBe(true);
            mockMovieService.Verify(x => x.AddMovie(movie), Times.Once());
        }
    }
}