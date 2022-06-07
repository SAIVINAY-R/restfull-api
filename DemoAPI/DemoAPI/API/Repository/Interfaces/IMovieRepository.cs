using System.Collections.Generic;
using DemoApp.RequestModels;

namespace DemoApp.Repository
{
    public interface IMovieRepository
    {
        public IList<ResponseModels.Movie> Get();
        public ResponseModels.Movie Get(int id);
        public void Create(Movie movie);
        public void Update(Movie movie);
        public void Delete(int id);
    }
}
