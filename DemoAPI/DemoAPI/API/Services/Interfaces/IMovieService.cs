using System.Collections.Generic;
using DemoApp.RequestModels;

namespace DemoApp.Services
{
    public interface IMovieService
    {
        public IList<ResponseModels.Movie> Get();
        public ResponseModels.Movie Get(int id);
        public void Create(Movie movie);
        public void Update(Movie movie);
        public void Delete(int id);
    }
}
