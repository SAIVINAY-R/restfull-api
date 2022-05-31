using System;
using System.Collections.Generic;
using DemoApp.Models;
using DemoApp.Repository;

namespace DemoApp.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public void Create(Genre genre)
        {
            if (genre == null)
                throw new ArgumentNullException();
            if (string.IsNullOrWhiteSpace(genre.Name))
                throw new ArgumentException();
            _genreRepository.Create(genre);
        }

        public void Delete(int id)
        {
            _genreRepository.Delete(id);
        }

        public IList<Genre> Get()
        {
            return _genreRepository.Get();
        }

        public Genre Get(int id)
        {
            return _genreRepository.Get(id);
        }

        public void Update(Genre genre)
        {
            _genreRepository.Update(genre);
        }
    }
}
