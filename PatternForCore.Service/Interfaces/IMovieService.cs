using PatternForCore.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatternForCore.Service.Interfaces
{
    public interface IMovieService
    {
        bool AddMovie(Movie movieItem);
        IList<Movie> GetMovies();
    }
}
