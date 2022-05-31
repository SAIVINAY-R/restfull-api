using System;
using System.Collections.Generic;
using DemoApp.Models;

namespace DemoApp.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private List<Genre> _genres;
        public GenreRepository()
        {
            _genres = new List<Genre>();
        }
        public void Create(Genre genre)
        {
            if (_genres.Exists(g => g.Id == genre.Id))
                throw new Exception();
            _genres.Add(genre);
        }

        public void Delete(int id)
        {
            if (!(_genres.Exists(genre => genre.Id == id)))
                throw new Exception();
            _genres.RemoveAll(genre => genre.Id == id);
        }

        public IList<Genre> Get() => _genres;

        public Genre Get(int id)
        {
            if (!(_genres.Exists(genre => genre.Id == id)))
                throw new Exception();
            return _genres.Find(genre => genre.Id == id);
        }

        public void Update(Genre genre)
        {
            var index = _genres.FindIndex(g => g.Id == genre.Id);
            if (index == -1)
                throw new Exception();
            _genres[index] = genre;
        }
    }
}
