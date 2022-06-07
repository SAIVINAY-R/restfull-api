using System;
using System.Collections.Generic;
using DemoApp.RequestModels;

namespace DemoApp.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private List<DBModels.Genre> _genres;
        public GenreRepository()
        {
            _genres = new List<DBModels.Genre>();
        }

        public void Create(Genre genre)
        {
            _genres.Add(new DBModels.Genre
            {
                Id = genre.Id,
                Name = genre.Name,
            });
        }

        public void Delete(int id)
        {
            _genres.Remove(_genres.Find(g => g.Id == id));
        }

        public IList<ResponseModels.Genre> Get()
        {
            var genres = new List<ResponseModels.Genre>();
            foreach (var genre in _genres)
                genres.Add(new ResponseModels.Genre
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            return genres;
        }

        public ResponseModels.Genre Get(int id)
        {
            var genre = _genres.Find(genre => genre.Id == id);
            if (genre == null)
                return default(ResponseModels.Genre);
            return new ResponseModels.Genre
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public void Update(Genre genre)
        {
            _genres[_genres.FindIndex(g => g.Id == genre.Id)] = new DBModels.Genre
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }
    }
}
