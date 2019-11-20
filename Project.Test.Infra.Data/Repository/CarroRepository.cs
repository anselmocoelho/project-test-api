using Project.Test.Domain.Entity;
using Project.Test.Domain.Interfaces.Repository;
using Project.Test.Infra.Data.Context;

namespace Project.Test.Infra.Data.Repository
{
    public class CarroRepository : BaseRepository<Carro>, ICarroRepository
    {
        private readonly TestContext _context;

        public CarroRepository(TestContext context) : base(context)
        {
            _context = context;
        }
    }
}