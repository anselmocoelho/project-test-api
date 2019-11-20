using Project.Test.Domain.Entity;
using Project.Test.Domain.Interfaces.Repository;
using Project.Test.Domain.Interfaces.Service;

namespace Project.Test.Domain.Service
{
    public class ManobristaService : BaseService<Manobrista>, IManobristaService
    {
        private readonly IManobristaRepository _repository;

        public ManobristaService(IManobristaRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}