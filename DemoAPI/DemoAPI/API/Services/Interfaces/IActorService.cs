using System.Collections.Generic;
using DemoApp.Models;

namespace DemoApp.Services
{
    public interface IActorService
    {
        public IList<Actor> Get();
        public Actor Get(int id);
        public void Create(Actor actor);
        public void Update(Actor actor);
        public void Delete(int id);
    }
}
