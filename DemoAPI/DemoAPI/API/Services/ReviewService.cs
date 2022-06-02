using System;
using System.Collections.Generic;
using DemoApp.Models;
using DemoApp.Repository;

namespace DemoApp.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMovieRepository _movieRepository;
        public ReviewService(IReviewRepository reviewRepository, IMovieRepository movieRepository)
        {
            _reviewRepository = reviewRepository;
            _movieRepository = movieRepository;
        }
        public void Create(Review review)
        {
            if (review == null)
                throw new ArgumentNullException();
            if (string.IsNullOrWhiteSpace(review.Message))
                throw new Exception("Message is empty");

            var movies = (List<Movie>)_movieRepository.Get();
            if (!(movies.Exists(movie => movie.Id == review.MovieId)))
                throw new Exception("Movie not found");

            var reviews = (List<Review>)_reviewRepository.Get(review.MovieId);
            if (reviews.Exists(r => r.Id == review.Id && r.MovieId == review.MovieId))
                throw new Exception("Review already exists");

            _reviewRepository.Create(review);
        }

        public void Delete(int movieId, int reviewId)
        {
            var reviews = (List<Review>)_reviewRepository.Get(movieId);
            if (!(reviews.Exists(review => review.Id == reviewId)))
                throw new Exception("Review not found");
            _reviewRepository.Delete(movieId, reviewId);
        }

        public IList<Review> Get(int movieId)
        {
            var reviews = _reviewRepository.Get(movieId);
            if (reviews.Count == 0)
            {
                throw new Exception("No reviews with the movie Id");
            }
            return reviews;
        }

        public Review Get(int movieId, int reviewId)
        {
            var reviews = (List<Review>)_reviewRepository.Get(movieId);
            if (!(reviews.Exists(review => review.Id == reviewId)))
                throw new Exception("Review not found");
            return _reviewRepository.Get(movieId, reviewId);   
        }

        public void Update(Review review)
        {
            if (review == null)
                throw new ArgumentNullException();

            var reviews = (List<Review>)_reviewRepository.Get(review.MovieId);
            if (!(reviews.Exists(r => r.Id == review.Id)))
                throw new Exception("Review not found");

            _reviewRepository.Update(review);
        }
    }
}
