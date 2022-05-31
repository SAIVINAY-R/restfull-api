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
            if (
                string.IsNullOrWhiteSpace(actor.Name) ||
                string.IsNullOrWhiteSpace(actor.Bio) ||
                string.IsNullOrWhiteSpace(actor.Gender)
                )
                throw new ArgumentException();
            _actorRepository.Create(actor);
        }

        public void Delete(int id)
        {
            _actorRepository.Delete(id);
        }

        public IList<Actor> Get()
        {
            return _actorRepository.Get();
        }

        public Actor Get(int id)
        {
            return _actorRepository.Get(id);
        }

        public void Update(Actor actor)
        {
            _actorRepository.Update(actor);
        }
    }
}
