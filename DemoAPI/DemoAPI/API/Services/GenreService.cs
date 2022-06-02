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
                throw new Exception("Genre Name is empty");

            var genres = (List<Genre>)_genreRepository.Get();
            if (genres.Exists(g => g.Id == genre.Id))
                throw new Exception("Genre already exists");

            _genreRepository.Create(genre);
        }

        public void Delete(int id)
        {
            var genre = _genreRepository.Get(id);
            if (default(Genre) == genre)
                throw new Exception("Genre not found");

            _genreRepository.Delete(id);
        }

        public IList<Genre> Get()
        {
            return _genreRepository.Get();
        }

        public Genre Get(int id)
        {
            var genre = _genreRepository.Get(id);
            if (default(Genre) == genre)
                throw new Exception("Genre not found");
            return genre;
        }

        public void Update(Genre genre)
        {
            var oldGenre = _genreRepository.Get(genre.Id);
            if (default(Genre) == oldGenre)
                throw new Exception("Genre not found");

            _genreRepository.Update(genre);
        }
    }
}
