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
            if (
                string.IsNullOrWhiteSpace(producer.Name) ||
                string.IsNullOrWhiteSpace(producer.Bio) ||
                string.IsNullOrWhiteSpace(producer.Gender)
                )
                throw new ArgumentException();
            _producerRepository.Create(producer);
        }

        public void Delete(int id)
        {
            _producerRepository.Delete(id);
        }

        public IList<Producer> Get()
        {
            return _producerRepository.Get();
        }

        public Producer Get(int id)
        {
            return _producerRepository.Get(id);
        }

        public void Update(Producer producer)
        {
            _producerRepository.Update(producer);
        }
    }
}
