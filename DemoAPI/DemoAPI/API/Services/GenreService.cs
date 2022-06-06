using System;
using System.Collections.Generic;
using DemoApp.CustomeExceptions;
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
                throw new ArgumentException("Genre Name is empty");

            if (_genreRepository.Get(genre.Id) != null)
                throw new EntityAlreadyExistException("Genre already exists");

            _genreRepository.Create(genre);
        }

        public void Delete(int id)
        {
            if (_genreRepository.Get(id) == null)
                throw new KeyNotFoundException("Genre not found");

            _genreRepository.Delete(id);
        }

        public IList<Genre> Get()
        {
            return _genreRepository.Get();
        }

        public Genre Get(int id)
        {
            var genre = _genreRepository.Get(id);
            if (genre == null)
                throw new KeyNotFoundException("Genre not found");
            return genre;
        }

        public void Update(Genre genre)
        {
            if (genre == null)
                throw new ArgumentNullException();

            if (_genreRepository.Get(genre.Id) == null)
                throw new KeyNotFoundException("Genre not found");

            _genreRepository.Update(genre);
        }
    }
}
