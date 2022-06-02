using System;
using System.Collections.Generic;
using DemoApp.Models;
using DemoApp.Repository;

namespace DemoApp.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;

        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public void Create(Actor actor)
        {
            if (actor == null)
                throw new ArgumentNullException();

            if (string.IsNullOrWhiteSpace(actor.Name))
                throw new Exception("Actor name is empty");

            if (string.IsNullOrWhiteSpace(actor.Bio))
                throw new Exception("Actor Bio is empty");

            if (string.IsNullOrWhiteSpace(actor.Gender))
                throw new Exception("Provide Actor Gender");

            var actors = (List<Actor>)_actorRepository.Get();
            if (actors.Exists(a => a.Id == actor.Id))
                throw new Exception("Actor already exists");

            _actorRepository.Create(actor);
        }

        public void Delete(int id)
        {
            var actor = _actorRepository.Get(id);
            if (default(Actor) == actor)
                throw new Exception("Actor not found");
            _actorRepository.Delete(id);
        }

        public IList<Actor> Get()
        {
            return _actorRepository.Get();
        }

        public Actor Get(int id)
        {
            var actor = _actorRepository.Get(id);
            if (default(Actor) == actor)
                throw new Exception("Actor not found");
            return actor;
        }

        public void Update(Actor actor)
        {
            if (actor == null)
                throw new ArgumentNullException();

            var oldActor = _actorRepository.Get(actor.Id);
            if (default(Actor) == oldActor)
                throw new Exception("Actor not found");

            _actorRepository.Update(actor);
        }
    }
}
