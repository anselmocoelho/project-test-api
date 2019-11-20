using Project.Test.Domain.Entity;
using Project.Test.Domain.Interfaces.Repository;
using Project.Test.Infra.Data.Context;

namespace Project.Test.Infra.Data.Repository
{
    public class ManobraRepository : BaseRepository<Manobra>, IManobraRepository
    {
        private readonly TestContext _context;

        public ManobraRepository(TestContext context) : base(context)
        {
            _context = context;
        }
    }
}