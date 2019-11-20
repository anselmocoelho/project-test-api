using Project.Test.Domain.Entity;
using Project.Test.Domain.Interfaces.Repository;
using Project.Test.Infra.Data.Context;

namespace Project.Test.Infra.Data.Repository
{
    public class ManobristaRepository : BaseRepository<Manobrista>, IManobristaRepository
    {
        private readonly TestContext _context;

        public ManobristaRepository(TestContext context) : base(context)
        {
            _context = context;
        }
    }
}