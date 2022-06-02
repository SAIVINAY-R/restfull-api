using System;
using System.Collections.Generic;
using DemoApp.Models;
using DemoApp.Repository;

namespace DemoApp.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IProducerRepository _producerRepository;
        private  readonly IGenreRepository _genreRepository;
        public MovieService(IMovieRepository movieRepository, IActorRepository actorRepository, IProducerRepository producerRepository, IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
            _producerRepository = producerRepository;
            _genreRepository = genreRepository;
        }
        public void Create(Movie movie)
        {
            if (movie == null)
                throw new Exception("Movie points to null");

            if (string.IsNullOrWhiteSpace(movie.Name))
                throw new Exception("movie Name is empty");

            if (string.IsNullOrWhiteSpace(movie.Plot))
                throw new Exception("Movie plot is empty");

            if (string.IsNullOrWhiteSpace(movie.CoverImage))
                throw new Exception("Movie cover image is empty");

            if (movie.ActorIds.Count == 0)
                throw new Exception("Movie should contain atleas one actor");

            var actors = (List<Actor>)_actorRepository.Get();
            foreach (var actorId in movie.ActorIds)
            {
                if (!(actors.Exists(actor => actor.Id == actorId)))
                    throw new Exception("Invalid Actor ID");
            }
            if (!(((List<Producer>)_producerRepository.Get()).Exists(producer => producer.Id == movie.ProducerId)))
                throw new Exception("Invalid Producer ID");

            var genres = (List<Genre>)_genreRepository.Get();
            foreach (var genreId in movie.Genres)
            {
                if (!(genres.Exists(genre => genre.Id == genreId)))
                    throw new Exception("Invalid Genre ID");
            }

            var movies = (List<Movie>)_movieRepository.Get();
            if (movies.Exists(m => m.Id == movie.Id))
                throw new Exception("Movie already exists");

            _movieRepository.Create(movie);
        }

        public void Delete(int id)
        {
            var movie = _movieRepository.Get(id);
            if (default(Movie) == movie)
                throw new Exception("Movie not in the list");
            _movieRepository.Delete(id);
        }

        public IList<Movie> Get()
        {
            return _movieRepository.Get();
        }

        public Movie Get(int id)
        {
            var movie = _movieRepository.Get(id);
            if (default(Movie) == movie)
                throw new Exception("Movie not in the list");
            return movie;
        }

        public void Update(Movie movie)
        {
            if (movie == null)
                throw new ArgumentNullException();

            var oldMovie = _movieRepository.Get(movie.Id);
            if (default(Movie) == oldMovie)
                throw new Exception("Movie not in the list");

            _movieRepository.Update(movie);
        }
    }
}
