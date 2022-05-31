using System;
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
            if (_actors.Exists(a => a.Id == actor.Id))
                throw new Exception();
            _actors.Add(actor);
        }

        public void Delete(int id)
        {
            if(!(_actors.Exists(_actor => _actor.Id == id)))
                throw new Exception();
            _actors.RemoveAll(actor => actor.Id == id);
        }

        public IList<Actor> Get() => _actors;

        public Actor Get(int id)
        {
            if (!(_actors.Exists(_actor => _actor.Id == id)))
                throw new Exception();
            return _actors.Find(actor => actor.Id == id);
        }

        public void Update(Actor actor)
        {
            var index = _actors.FindIndex(a => a.Id == actor.Id);
            if (index == -1)
                throw new Exception();
            _actors[index] = actor;
        }
    }
}
