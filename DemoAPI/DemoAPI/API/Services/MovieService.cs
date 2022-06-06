using System;
using System.Collections.Generic;
using DemoApp.CustomeExceptions;
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
                throw new ArgumentNullException("Movie points to null");

            if (string.IsNullOrWhiteSpace(movie.Name))
                throw new ArgumentException("movie Name is empty");

            if (string.IsNullOrWhiteSpace(movie.Plot))
                throw new ArgumentException("Movie plot is empty");

            if (movie.ActorIds.Count == 0)
                throw new ArgumentException("Movie should contain atleas one actor");

            foreach (var actorId in movie.ActorIds)
            {
                if (_actorRepository.Get(actorId) == null)
                    throw new KeyNotFoundException("Invalid Actor ID");
            }
            if (_producerRepository.Get(movie.ProducerId) == null)
                throw new KeyNotFoundException("Invalid Producer ID");

            foreach (var genreId in movie.Genres)
            {
                if (_genreRepository.Get(genreId) == null)
                    throw new KeyNotFoundException("Invalid Genre ID");
            }

            if (_movieRepository.Get(movie.Id) != null)
                throw new EntityAlreadyExistException("Movie already exists");

            _movieRepository.Create(movie);
        }

        public void Delete(int id)
        {
            if (_movieRepository.Get(id) == null)
                throw new KeyNotFoundException("Movie not in the list");
            _movieRepository.Delete(id);
        }

        public IList<Movie> Get()
        {
            return _movieRepository.Get();
        }

        public Movie Get(int id)
        {
            var movie = _movieRepository.Get(id);
            if (movie == null)
                throw new KeyNotFoundException("Movie not in the list");
            return movie;
        }

        public void Update(Movie movie)
        {
            if (movie == null)
                throw new ArgumentNullException();

            if (_movieRepository.Get(movie.Id) == null)
                throw new KeyNotFoundException("Movie not in the list");

            _movieRepository.Update(movie);
        }
    }
}
