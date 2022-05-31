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
            {
                throw new Exception();
            }
            if (string.IsNullOrWhiteSpace(movie.Name) ||
                string.IsNullOrWhiteSpace(movie.Plot) ||
                string.IsNullOrWhiteSpace(movie.CoverImage) ||
                movie.ActorIds.Count == 0)
                throw new Exception();

            foreach (var actorId in movie.ActorIds)
            {
                _actorRepository.Get(actorId);
            }
            _producerRepository.Get(movie.ProducerId);
            foreach (var genreId in movie.Genres)
            {
                _genreRepository.Get(genreId);
            }
            _movieRepository.Create(movie);
        }

        public void Delete(int id)
        {
            _movieRepository.Delete(id);
        }

        public IList<Movie> Get()
        {
            return _movieRepository.Get();
        }

        public Movie Get(int id)
        {
            return _movieRepository.Get(id);
        }

        public void Update(Movie movie)
        {
            _movieRepository.Update(movie);
        }
    }
}
