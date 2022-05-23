using System.Collections.Generic;
using DemoApp.Models;

namespace DemoApp.Services
{
    public interface IActorService
    {
        public IEnumerable<Actor> GetAll();
    }
}
