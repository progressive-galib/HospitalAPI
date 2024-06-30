using HospitalAPI.Data;
using HospitalAPI.Entities;
using HospitalAPI.IRepositories;

namespace HospitalAPI.Repositories
{
    public class NCDRepository : Repository<NCD>, INCDRepository
    {
        public NCDRepository(ApplicationDbContext context) : base(context) { }

        public NCD GetByName(string name)
        {
            return _context.NCDs.SingleOrDefault(n => n.Name == name);
        }
    }
}
