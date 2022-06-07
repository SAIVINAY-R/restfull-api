using System;
using System.Collections.Generic;
using DemoApp.RequestModels;

namespace DemoApp.Repository
{
    public class ProducerRepository : IProducerRepository
    {
        private List<DBModels.Producer> _producers;
        public ProducerRepository()
        {
            _producers = new List<DBModels.Producer>();
        }

        public void Create(Producer producer)
        {
            _producers.Add(new DBModels.Producer
            {
                Id = producer.Id,
                Name = producer.Name,
                DOB = producer.DOB,
                Bio = producer.Bio,
                Gender = producer.Gender
            });
        }

        public void Delete(int id)
        {
            _producers.Remove(_producers.Find(producer => producer.Id == id));
        }

        public IList<ResponseModels.Producer> Get()
        {
            var producers = new List<ResponseModels.Producer>();
            foreach (var producer in _producers)
                producers.Add(new ResponseModels.Producer
                {
                    Id = producer.Id,
                    Name = producer.Name,
                    DOB = producer.DOB,
                    Bio = producer.Bio,
                    Gender = producer.Gender
                });
            return producers;
        }

        public ResponseModels.Producer Get(int id)
        {
            var producer = _producers.Find(p => p.Id == id);
            if (producer == null)
                return default(ResponseModels.Producer);
            return new ResponseModels.Producer
            {
                Id = producer.Id,
                Name = producer.Name,
                DOB = producer.DOB,
                Bio = producer.Bio,
                Gender = producer.Gender
            };
        }

        public void Update(Producer producer)
        {
            _producers[_producers.FindIndex(p => p.Id == producer.Id)] = new DBModels.Producer
            {
                Id = producer.Id,
                Name = producer.Name,
                DOB = producer.DOB,
                Bio = producer.Bio,
                Gender = producer.Gender
            };
        }
    }
}
