using System;
using System.Collections.Generic;
using DemoApp.CustomeExceptions;
using DemoApp.RequestModels;
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
                throw new ArgumentException("Message is empty");

            if (_movieRepository.Get(review.MovieId) == null)
                throw new KeyNotFoundException("Movie not found");

            if (_reviewRepository.Get(review.MovieId, review.Id) != null)
                throw new EntityAlreadyExistException("Review already exists");

            _reviewRepository.Create(review);
        }

        public void Delete(int movieId, int reviewId)
        {
            if (_reviewRepository.Get(movieId, reviewId) == null)
                throw new KeyNotFoundException("Review not found");
            _reviewRepository.Delete(movieId, reviewId);
        }

        public IList<ResponseModels.Review> Get(int movieId)
        {
            var reviews = _reviewRepository.Get(movieId);
            if (reviews.Count == 0)
            {
                throw new KeyNotFoundException("No reviews with the movie Id");
            }
            return reviews;
        }

        public ResponseModels.Review Get(int movieId, int reviewId)
        {
            var review = _reviewRepository.Get(movieId, reviewId);
            if (review == null)
                throw new KeyNotFoundException("Review not found");
            return review;   
        }

        public void Update(Review review)
        {
            if (review == null)
                throw new ArgumentNullException();

            if (_reviewRepository.Get(review.MovieId, review.Id) == null)
                throw new KeyNotFoundException("Review not found");

            _reviewRepository.Update(review);
        }
    }
}
