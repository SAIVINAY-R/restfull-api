using System.Collections.Generic;
using DemoApp.Models;

namespace DemoApp.Repository
{
    public interface IReviewRepository
    {
        public IList<Review> Get(int movieId);
        public Review Get(int movieId, int reviewId);
        public void Create(Review review);
        public void Update(Review review);
        public void Delete(int movieId, int reviewId);
    }
}
