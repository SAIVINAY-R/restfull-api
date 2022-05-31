using System;
using System.Collections.Generic;
using DemoApp.Models;

namespace DemoApp.Repository
{
    public class ProducerRepository : IProducerRepository
    {
        private List<Producer> _producers;
        public ProducerRepository()
        {
            _producers = new List<Producer>();
        }
        public void Create(Producer producer)
        {
            if (_producers.Exists(p => p.Id == producer.Id))
                throw new Exception();
            _producers.Add(producer);
        }

        public void Delete(int id)
        {
            if (!(_producers.Exists(producer => producer.Id == id)))
                throw new Exception();
            _producers.RemoveAll(producer => producer.Id == id);
        }

        public IList<Producer> Get() => _producers;

        public Producer Get(int id)
        {
            if (!(_producers.Exists(producer => producer.Id == id)))
                throw new Exception();
            return _producers.Find(producer => producer.Id == id);
        }

        public void Update(Producer producer)
        {
            var index = _producers.FindIndex(p => p.Id == producer.Id);
            if (index == -1)
                throw new Exception();
            _producers[index] = producer;
        }
    }
}
