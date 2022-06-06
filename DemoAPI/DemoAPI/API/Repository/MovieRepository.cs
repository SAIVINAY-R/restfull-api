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
            _movies.Add(movie);
        }

        public void Delete(int id)
        {
            _movies.Remove(_movies.Find(movie => movie.Id == id));
        }

        public IList<Movie> Get()
        {
            return _movies;
        }

        public Movie Get(int id)
        {
            return _movies.Find(movie => movie.Id == id);
        }

        public void Update(Movie movie)
        {
            _movies[_movies.FindIndex(m => m.Id == movie.Id)] = movie;
        }
    }
}