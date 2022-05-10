using API.DbContext;
using API.DTO;
using System;
using System.Collections.Generic;

namespace API.Service
{
    public class MovieService
    {
        private readonly Context _context;

        public MovieService(Context context)
        {
            this._context = context;
        }

        public IEnumerable<MovieDTO> GetMoviesList()
        {
            throw new NotImplementedException();
        }

        public MovieDTO GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public int CreateMovie(MovieDTO input)
        {
            throw new NotImplementedException();
        }

        public int UpdateMovie(MovieDTO input)
        {
            throw new NotImplementedException();
        }

        public int DeleteMovie(MovieDTO input)
        {
            throw new NotImplementedException();
        }
    }
}
