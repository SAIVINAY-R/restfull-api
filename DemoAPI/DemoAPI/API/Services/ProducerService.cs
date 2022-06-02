using System;
using System.Collections.Generic;
using DemoApp.Models;
using DemoApp.Repository;

namespace DemoApp.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepository;
        public ProducerService(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }
        public void Create(Producer producer)
        {
            if (producer == null)
                throw new ArgumentNullException();
            if (string.IsNullOrWhiteSpace(producer.Name))
                throw new Exception("Producer name is empty");

            if (string.IsNullOrWhiteSpace(producer.Bio))
                throw new Exception("Producer Bio is empty");

            if (string.IsNullOrWhiteSpace(producer.Gender))
                throw new Exception("Provide Producer Gender");

            var producers = (List<Producer>)_producerRepository.Get();
            if (producers.Exists(p => p.Id == producer.Id))
                throw new Exception("Producer already exists");

            _producerRepository.Create(producer);
        }

        public void Delete(int id)
        {
            var producer = _producerRepository.Get(id);
            if (default(Producer) == producer)
                throw new Exception("Producer not found");

            _producerRepository.Delete(id);
        }

        public IList<Producer> Get()
        {
            return _producerRepository.Get();
        }

        public Producer Get(int id)
        {
            var producer = _producerRepository.Get(id);
            if (default(Producer) == producer)
                throw new Exception("Producer not found");

            return producer;
        }

        public void Update(Producer producer)
        {
            var oldProducer = _producerRepository.Get(producer.Id);
            if (default(Producer) == oldProducer)
                throw new Exception("Producer not found");

            _producerRepository.Update(producer);
        }
    }
}
