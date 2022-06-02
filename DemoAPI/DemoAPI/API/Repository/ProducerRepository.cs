using System;
using System.Collections.Generic;
using DemoApp.Models;

namespace DemoApp.Repository
{
    public class ProducerRepository : IProducerRepository
    {
        private List<Producer> _producers;
        public ProducerRepository() => _producers = new List<Producer>();
        public void Create(Producer producer) => _producers.Add(producer);

        public void Delete(int id) => _producers.Remove(_producers.Find(producer => producer.Id == id));

        public IList<Producer> Get() => _producers;

        public Producer Get(int id) => _producers.Find(producer => producer.Id == id);

        public void Update(Producer producer) => _producers[_producers.FindIndex(p => p.Id == producer.Id)] = producer;
    }
}
