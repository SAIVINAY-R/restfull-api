using System;
using System.Collections.Generic;
using DemoApp.Models;

namespace DemoApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private List<Review> _reviews;
        public ReviewRepository()
        {
            _reviews = new List<Review>();
        }
        public void Create(Review review)
        {
            if (_reviews.Exists(r => r.Id == review.Id))
                throw new Exception();
            _reviews.Add(review);
        }

        public void Delete(int movieId, int reviewId)
        {
            if (!(_reviews.Exists(review => review.Id == reviewId && review.MovieId == movieId)))
                throw new Exception();
            _reviews.RemoveAll(review => review.Id == reviewId && review.MovieId == movieId);
        }

        public IList<Review> Get(int movieId) => _reviews.FindAll(review => review.MovieId == movieId);

        public Review Get(int movieId, int reviewId)
        {
            if (!(_reviews.Exists(review => review.Id == reviewId && review.MovieId == movieId)))
                throw new Exception();
            return _reviews.Find(review => review.Id == reviewId && review.MovieId == movieId);
        }

        public void Update(Review review)
        {
            var index = _reviews.FindIndex(r => r.Id == review.Id && r.MovieId == review.MovieId);
            if (index == -1)
                throw new Exception();
            _reviews[index] = review;
        }
    }
}
