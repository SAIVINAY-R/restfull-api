using System.Collections.Generic;
using DemoApp.Models;

namespace DemoApp.Services
{
    public interface IGenreService
    {
        public IList<Genre> Get();
        public Genre Get(int id);
        public void Create(Genre genre);
        public void Update(Genre genre);
        public void Delete(int id);
    }
}
