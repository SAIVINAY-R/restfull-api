using System.Collections.Generic;
using DemoApp.Models;

namespace DemoApp.Services
{
    public interface IProducerService
    {
        public IList<Producer> Get();
        public Producer Get(int id);
        public void Create(Producer producer);
        public void Update(Producer producer);
        public void Delete(int id);
    }
}
