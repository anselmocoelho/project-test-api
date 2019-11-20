using Project.Test.Domain.Entity;
using Project.Test.Domain.Interfaces.Repository;
using Project.Test.Domain.Interfaces.Service;

namespace Project.Test.Domain.Service
{
    public class CarroService : BaseService<Carro>, ICarroService
    {
        private readonly ICarroRepository _repository;

        public CarroService(ICarroRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}