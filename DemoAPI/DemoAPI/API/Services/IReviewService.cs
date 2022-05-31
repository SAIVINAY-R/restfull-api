using System.Collections.Generic;
using DemoApp.Models;

namespace DemoApp.Services
{
    public interface IReviewService
    {
        public IList<Review> Get(int movieId);
        public Review Get(int movieId, int reviewId);
        public void Create(Review review);
        public void Update(Review review);
        public void Delete(int movieId, int reviewId);
    }
}
