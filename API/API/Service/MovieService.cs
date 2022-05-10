using API.DbContext;
using API.DTO;
using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Service
{
    public interface IMovieService
    {
        IEnumerable<MovieDTO> GetMoviesList();
        MovieDTO GetMovieById(int id);
        int CreateMovie(MovieDTO input);
        bool UpdateMovie(MovieDTO input);
        bool DeleteMovie(int id);

    }

    public class MovieService : IMovieService
    {
        private readonly Context _context;

        public MovieService(Context context)
        {
            this._context = context;
        }

        public IEnumerable<MovieDTO> GetMoviesList()
        {
            return _context.Movies.Select(x => new MovieDTO
            {
                Id = x.Id,
                Title = x.Title,
                ProductionYear = x.ProductionYear
            }).ToList();
        }

        public MovieDTO GetMovieById(int id)
        {
            return _context.Movies.Where(x => x.Id == id).Select(x => new MovieDTO
            {
                Id = x.Id,
                Title = x.Title,
                ProductionYear = x.ProductionYear
            }).FirstOrDefault();
        }

        public int CreateMovie(MovieDTO input)
        {
            try
            {
                var buff = new Movie
                {
                    Title = input.Title,
                    ProductionYear = input.ProductionYear
                };

                _context.Movies.Add(buff);
                _context.SaveChanges();

                return buff.Id;
            }
            catch
            {
                return 0;
            }
        }

        public bool UpdateMovie(MovieDTO input)
        {
            try
            {
                var buff = new Movie
                {
                    Id = input.Id,
                    Title = input.Title,
                    ProductionYear = input.ProductionYear
                };

                _context.Movies.Update(buff);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteMovie(int id)
        {
            try
            {
                var buff = _context.Movies.Where(x => x.Id == id).FirstOrDefault();

                if (buff == null) return false;

                _context.Movies.Remove(buff);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
