using System;
using System.Collections.Generic;
using DemoApp.Models;

namespace DemoApp.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private List<Movie> _movies;
        public MovieRepository()
        {
            _movies = new List<Movie>();
        }
        public void Create(Movie movie)
        {
            if (_movies.Exists(m => m.Id == movie.Id))
                throw new Exception();
            _movies.Add(movie);
        }

        public void Delete(int id)
        {
            if (!(_movies.Exists(movie => movie.Id == id)))
                throw new Exception();
            _movies.RemoveAll(movie => movie.Id == id);
        }

        public IList<Movie> Get() => _movies;

        public Movie Get(int id)
        {
            if (!(_movies.Exists(movie => movie.Id == id)))
                throw new Exception();
            return _movies.Find(movie => movie.Id == id);
        }

        public void Update(Movie movie)
        {
            var index = _movies.FindIndex(m => m.Id == movie.Id);
            if (index == -1)
                throw new Exception();
            _movies[index] = movie;
        }
    }
}
