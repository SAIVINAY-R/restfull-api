using System;
using System.Collections.Generic;
using DemoApp.Models;

namespace DemoApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private List<Review> _reviews;
        public ReviewRepository() => _reviews = new List<Review>();
        public void Create(Review review) => _reviews.Add(review);

        public void Delete(int movieId, int reviewId) => _reviews.Remove(_reviews.Find(review => review.Id == reviewId && review.MovieId == movieId));

        public IList<Review> Get(int movieId) => _reviews.FindAll(review => review.MovieId == movieId);

        public Review Get(int movieId, int reviewId) => _reviews.Find(review => review.Id == reviewId && review.MovieId == movieId);

        public void Update(Review review) => _reviews[_reviews.FindIndex(r => r.Id == review.Id && r.MovieId == review.MovieId)] = review;
    }
}
