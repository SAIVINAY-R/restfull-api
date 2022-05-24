using System.Collections.Generic;
using DemoApp.Models;

namespace DemoApp.Repository
{
    public interface IActorRepository
    {
        public IEnumerable<Actor> GetAll();
    }
}
