using HospitalAPI.Data;
using HospitalAPI.Entities;
using HospitalAPI.IRepositories;

namespace HospitalAPI.Repositories
{
    public class DiseaseRepository : Repository<Disease>, IDiseaseRepository
    {
        public DiseaseRepository(ApplicationDbContext context) : base(context) { }

        public Disease GetByName(string name)
        {
            return _context.Diseases.SingleOrDefault(d => d.Name == name);
        }
    }
}
