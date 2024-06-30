using HospitalAPI.Data;
using HospitalAPI.Entities;
using HospitalAPI.IRepositories;

namespace HospitalAPI.Repositories
{
    public class AllergyRepository : Repository<Allergy>, IAllergyRepository
    {
        public AllergyRepository(ApplicationDbContext context) : base(context) { }

        public Allergy GetByName(string name)
        {
            return _context.Allergies.SingleOrDefault(a => a.Name == name);
        }
    }
}
