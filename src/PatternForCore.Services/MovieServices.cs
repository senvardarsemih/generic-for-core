using System;
using System.Collections.Generic;
using PatternForCore.Core.Uow;
using PatternForCore.Models.Common;
using System.Linq;
using PatternForCore.Services.Base.Contracts;

namespace PatternForCore.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieServices(IUnitOfWork unitOfWork)
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
