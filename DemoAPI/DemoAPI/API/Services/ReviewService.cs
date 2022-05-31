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
                throw new ArgumentException();
            //Below line checks wheater the movie with review.MovieId is present or not If not present throws an Exception
            _movieRepository.Get(review.MovieId);
            _reviewRepository.Create(review);
        }

        public void Delete(int movieId, int reviewId)
        {
            _reviewRepository.Delete(movieId, reviewId);
        }

        public IList<Review> Get(int movieId)
        {
            var reviews = _reviewRepository.Get(movieId);
            if (reviews.Count == 0)
            {
                throw new Exception();
            }
            return reviews;
        }

        public Review Get(int movieId, int reviewId)
        {
           return _reviewRepository.Get(movieId, reviewId);   
        }

        public void Update(Review review)
        {
            _reviewRepository.Update(review);
        }
    }
}
