using System.Collections.Generic;
using DemoApp.RequestModels;

namespace DemoApp.Repository
{
    public class ActorRepository : IActorRepository
    {
        private List<DBModels.Actor> _actors;
        public ActorRepository()
        {
            _actors = new List<DBModels.Actor>();
        }

        public void Create(Actor actor)
        {
            _actors.Add(new DBModels.Actor
            {
                Id = actor.Id,
                Name = actor.Name,
                DOB = actor.DOB,
                Bio = actor.Bio,
                Gender = actor.Gender
            });
        }

        public void Delete(int id)
        {
            _actors.Remove(_actors.Find(actor => actor.Id == id));
        }

        public IList<ResponseModels.Actor> Get()
        {
            var actors = new List<ResponseModels.Actor>();
            foreach (var actor in _actors)
                actors.Add(new ResponseModels.Actor
                {
                    Id = actor.Id,
                    Name = actor.Name,
                    DOB = actor.DOB,
                    Bio = actor.Bio,
                    Gender = actor.Gender
                });
            return actors;
        }

        public ResponseModels.Actor Get(int id)
        {
            var actor = _actors.Find(a => a.Id == id);
            if (actor == null)
                return default(ResponseModels.Actor);
            return new ResponseModels.Actor
            {
                Id = actor.Id,
                Name = actor.Name,
                DOB = actor.DOB,
                Bio = actor.Bio,
                Gender = actor.Gender
            };
        }

        public void Update(Actor actor)
        {
            _actors[_actors.FindIndex(a => a.Id == actor.Id)] = new DBModels.Actor
            {
                Id=actor.Id,
                Name = actor.Name,
                DOB = actor.DOB,
                Bio = actor.Bio,
                Gender = actor.Gender
            };
        }
    }
}
