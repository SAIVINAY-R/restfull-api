using System.Collections.Generic;
using DemoApp.RequestModels;

namespace DemoApp.Repository
{
    public interface IActorRepository
    {
        public IList<ResponseModels.Actor> Get();
        public ResponseModels.Actor Get(int id);
        public void Create(Actor actor);
        public void Update(Actor actor);
        public void Delete(int id);
    }
}
