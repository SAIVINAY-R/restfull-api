using System;
using System.Collections.Generic;
using DemoApp.CustomeExceptions;
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
                throw new ArgumentException("Producer name is empty");

            if (string.IsNullOrWhiteSpace(producer.Bio))
                throw new ArgumentException("Producer Bio is empty");

            if (_producerRepository.Get(producer.Id) != null)
                throw new EntityAlreadyExistException("Producer already exists");

            _producerRepository.Create(producer);
        }

        public void Delete(int id)
        {
            if (_producerRepository.Get(id) == null)
                throw new KeyNotFoundException("Producer not found");

            _producerRepository.Delete(id);
        }

        public IList<Producer> Get()
        {
            return _producerRepository.Get();
        }

        public Producer Get(int id)
        {
            var producer = _producerRepository.Get(id);
            if (producer == null)
                throw new KeyNotFoundException("Producer not found");

            return producer;
        }

        public void Update(Producer producer)
        {
            if (producer == null)
                throw new ArgumentNullException();

            if (_producerRepository.Get(producer.Id) == null)
                throw new KeyNotFoundException("Producer not found");

            _producerRepository.Update(producer);
        }
    }
}
