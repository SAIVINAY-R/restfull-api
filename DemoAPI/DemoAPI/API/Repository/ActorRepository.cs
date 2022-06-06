using System.Collections.Generic;
using DemoApp.Models;

namespace DemoApp.Repository
{
    public class ActorRepository : IActorRepository
    {
        private List<Actor> _actors;
        public ActorRepository()
        {
            _actors = new List<Actor>();
        }

        public void Create(Actor actor)
        {
            _actors.Add(actor);
        }

        public void Delete(int id)
        {
            _actors.Remove(_actors.Find(actor => actor.Id == id));
        }

        public IList<Actor> Get()
        {
            return _actors;
        }

        public Actor Get(int id)
        {
            return _actors.Find(actor => actor.Id == id);
        }

        public void Update(Actor actor)
        {
            _actors[_actors.FindIndex(a => a.Id == actor.Id)] = actor;
        }
    }
}
