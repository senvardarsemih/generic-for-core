using System;
using System.Collections.Generic;
using System.Linq;
using PatternForCore.Data.UOW;
using PatternForCore.Model.Common;
using PatternForCore.Service.Interfaces;

namespace PatternForCore.Service
{
    public class MovieService : IMovieService
    {

        private readonly IUnitOfWork _unitOfWork;
        public MovieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
       
        public bool AddMovie(Movie movieItem)
        {
            bool result = false;

            try
            {
                if (movieItem != null)
                {
                    var movieRepository = _unitOfWork.GetRepository<Movie>();
                    movieRepository.Add(movieItem);
                    _unitOfWork.Commit();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return result;
        }

        public IList<Movie> GetMovies()
        {
            var movieRepository = _unitOfWork.GetRepository<Movie>();
            return movieRepository.GetAll().OrderByDescending(x => x.Id).Take(10).ToList();
        }

    }
}
