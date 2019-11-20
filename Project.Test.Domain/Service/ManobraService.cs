using Project.Test.Domain.Entity;
using Project.Test.Domain.Interfaces.Repository;
using Project.Test.Domain.Interfaces.Service;

namespace Project.Test.Domain.Service
{
    public class ManobraService : BaseService<Manobra>, IManobraService
    {
        private readonly IManobraRepository _repository;

        public ManobraService(IManobraRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}