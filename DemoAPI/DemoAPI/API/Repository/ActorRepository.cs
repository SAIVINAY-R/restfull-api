using System;
using System.Collections.Generic;
using DemoApp.Models;

namespace DemoApp.Repository
{
    public class ActorRepository : IActorRepository
    {
        /// <inheritdoc />
        public IEnumerable<Actor> GetAll()
        {
            return new List<Actor>
            {
                new Actor
                {
                    Id = 1,
                    Name = "Actor 1",
                    Bio = "--",
                    DOB = DateTime.Now.AddYears(-22)
                },
                new Actor
                {
                    Id = 2,
                    Name = "Actor ",
                    Bio = "--",
                    DOB = DateTime.Now.AddYears(-20)
                },
            };
        }
    }
}
