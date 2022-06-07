using System.Collections.Generic;
using DemoApp.RequestModels;

namespace DemoApp.Repository
{
    public interface IReviewRepository
    {
        public IList<ResponseModels.Review> Get(int movieId);
        public ResponseModels.Review Get(int movieId, int reviewId);
        public void Create(Review review);
        public void Update(Review review);
        public void Delete(int movieId, int reviewId);
    }
}
