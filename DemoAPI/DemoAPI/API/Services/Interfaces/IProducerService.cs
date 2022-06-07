using System.Collections.Generic;
using DemoApp.RequestModels;

namespace DemoApp.Services
{
    public interface IProducerService
    {
        public IList<ResponseModels.Producer> Get();
        public ResponseModels.Producer Get(int id);
        public void Create(Producer producer);
        public void Update(Producer producer);
        public void Delete(int id);
    }
}
