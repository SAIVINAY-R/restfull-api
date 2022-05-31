using System.Collections.Generic;
using DemoApp.Models;

namespace DemoApp.Repository
{
    public interface IMovieRepository
    {
        public IList<Movie> Get();
        public Movie Get(int id);
        public void Create(Movie movie);
        public void Update(Movie movie);
        public void Delete(int id);
    }
}
