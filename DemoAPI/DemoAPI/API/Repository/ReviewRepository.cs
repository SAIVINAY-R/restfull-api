using System;
using System.Collections.Generic;
using DemoApp.RequestModels;

namespace DemoApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private List<DBModels.Review> _reviews;
        public ReviewRepository()
        {
            _reviews = new List<DBModels.Review>();
        }

        public void Create(Review review)
        {
            _reviews.Add(new DBModels.Review
            {
                Id = review.Id,
                Message = review.Message,
                MovieId = review.MovieId
            });
        }

        public void Delete(int movieId, int reviewId)
        {
            _reviews.Remove(_reviews.Find(review => review.Id == reviewId && review.MovieId == movieId));
        }

        public IList<ResponseModels.Review> Get(int movieId)
        {
            var reviews = new List<ResponseModels.Review>();
            foreach (var review in _reviews)
                reviews.Add(new ResponseModels.Review
                {
                    Id = review.Id,
                    MovieId = review.MovieId,
                    Message = review.Message
                });
            return reviews;
        }

        public ResponseModels.Review Get(int movieId, int reviewId)
        {
            var review = _reviews.Find(r => r.Id == reviewId && r.MovieId == movieId);
            if (review == null)
                return default(ResponseModels.Review);
            return new ResponseModels.Review
            {
                Id = review.Id,
                Message = review.Message,
                MovieId = review.MovieId,
            };
        }

        public void Update(Review review)
        {
            _reviews[_reviews.FindIndex(r => r.Id == review.Id && r.MovieId == review.MovieId)] = new DBModels.Review
            {
                Id = review.Id,
                MovieId = review.MovieId,
                Message = review.Message,
            };
        }
    }
}
