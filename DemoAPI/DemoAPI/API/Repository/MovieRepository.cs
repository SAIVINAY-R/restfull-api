using System.Collections.Generic;
using DemoApp.RequestModels;

namespace DemoApp.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private List<DBModels.Movie> _movies;
        private Dictionary<int,List<int>> _actorsMoviesMapping;
        private Dictionary<int, List<int>> _genresMoviesMapping;
        public MovieRepository()
        {
            _movies = new List<DBModels.Movie>();
            _actorsMoviesMapping = new Dictionary<int, List<int>>();
            _genresMoviesMapping = new Dictionary<int, List<int>>();
        }

        public void Create(Movie movie)
        {
            _movies.Add(new DBModels.Movie
            {
                Id = movie.Id,
                Name = movie.Name,
                Plot = movie.Plot,
                ProducerId = movie.ProducerId,
                YearOfRelease = movie.YearOfRelease,
                CoverImage = movie.CoverImage,
            });
            _actorsMoviesMapping.Add(movie.Id, movie.ActorIds);
            _genresMoviesMapping.Add(movie.Id, movie.Genres);
        }

        public void Delete(int id)
        {
            _movies.Remove(_movies.Find(movie => movie.Id == id));
        }

        public IList<ResponseModels.Movie> Get()
        {
            var movies = new List<ResponseModels.Movie>();
            foreach (var movie in _movies)
                movies.Add(new ResponseModels.Movie
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Plot = movie.Plot,
                    YearOfRelease = movie.YearOfRelease,
                    ActorIds = _actorsMoviesMapping[movie.Id],
                    Genres = _genresMoviesMapping[movie.Id],
                    ProducerId = movie.ProducerId,
                    CoverImage = movie.CoverImage
                });
           return movies;
        }

        public ResponseModels.Movie Get(int id)
        {
            var movie = _movies.Find(m => m.Id == id);
            if (movie == null)
                return default(ResponseModels.Movie);
            return new ResponseModels.Movie
            {
                Id = movie.Id,
                Name = movie.Name,
                Plot = movie.Plot,
                YearOfRelease = movie.YearOfRelease,
                ActorIds = _actorsMoviesMapping[movie.Id],
                Genres = _genresMoviesMapping[movie.Id],
                ProducerId = movie.ProducerId,
                CoverImage = movie.CoverImage
            };
        }

        public void Update(Movie movie)
        {
            _movies[_movies.FindIndex(m => m.Id == movie.Id)] = new DBModels.Movie
            {
                Id = movie.Id,
                Name = movie.Name,
                Plot = movie.Plot,
                YearOfRelease = movie.YearOfRelease,
                ProducerId = movie.ProducerId,
                CoverImage = movie.CoverImage
            };
            _actorsMoviesMapping[movie.Id] = movie.ActorIds;
            _genresMoviesMapping[movie.Id] = movie.Genres;
        }
    }
}