using System.Collections.Generic;
using PatternForCore.Models.Common;

namespace PatternForCore.Services.Base.Contracts
{
    public interface IMovieServices
    {
        bool AddMovie(Movie movieItem);
        IList<Movie> GetMovies();
    }
}
