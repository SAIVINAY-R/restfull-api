using System.Collections.Generic;
using DemoApp.RequestModels;

namespace DemoApp.Services
{
    public interface IGenreService
    {
        public IList<ResponseModels.Genre> Get();
        public ResponseModels.Genre Get(int id);
        public void Create(Genre genre);
        public void Update(Genre genre);
        public void Delete(int id);
    }
}
