using System;
using System.Collections.Generic;
using DemoApp.CustomeExceptions;
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
                throw new ArgumentException("Actor name is empty");

            if (string.IsNullOrWhiteSpace(actor.Bio))
                throw new ArgumentException("Actor Bio is empty");

            if(_actorRepository.Get(actor.Id) != null)
                throw new EntityAlreadyExistException("Actor already exists");

            _actorRepository.Create(actor);
        }

        public void Delete(int id)
        {
            if (_actorRepository.Get(id) == null)
                throw new KeyNotFoundException("Actor not found");
            _actorRepository.Delete(id);
        }

        public IList<Actor> Get()
        {
            return _actorRepository.Get();
        }

        public Actor Get(int id)
        {
            var actor = _actorRepository.Get(id);
            if (actor == null)
                throw new KeyNotFoundException("Actor not found");
            return actor;
        }

        public void Update(Actor actor)
        {
            if (actor == null)
                throw new ArgumentNullException();

            if (_actorRepository.Get(actor.Id) == null)
                throw new KeyNotFoundException("Actor not found");

            _actorRepository.Update(actor);
        }
    }
}
