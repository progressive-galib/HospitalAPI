using HospitalAPI.Data;
using HospitalAPI.Entities;
using HospitalAPI.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Patient> GetPatientWithDetailsAsync(int id)
        {
            return await _context.Patients
                .Include(p => p.Disease)
                .Include(p => p.PatientNCDs)
                    .ThenInclude(pn => pn.NCD)
                .Include(p => p.PatientAllergies)
                    .ThenInclude(pa => pa.Allergy)
                .SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
