using System;
using System.Collections.Generic;
using DemoApp.Models;

namespace DemoApp.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private List<Genre> _genres;
        public GenreRepository() => _genres = new List<Genre>();
        public void Create(Genre genre) => _genres.Add(genre);

        public void Delete(int id) => _genres.Remove(_genres.Find(genre => genre.Id == id));

        public IList<Genre> Get() => _genres;

        public Genre Get(int id) => _genres.Find(genre => genre.Id == id);

        public void Update(Genre genre) => _genres[_genres.FindIndex(g => g.Id == genre.Id)] = genre;
    }
}
