using HospitalAPI.Data;
using HospitalAPI.IRepositories;

namespace HospitalAPI.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IPatientRepository Patients { get; }
        public IDiseaseRepository Diseases { get; }
        public INCDRepository NCDs { get; }
        public IAllergyRepository Allergies { get; }

        public UnitOfWork(ApplicationDbContext context, IPatientRepository patientRepository, IDiseaseRepository diseaseRepository, INCDRepository ncdRepository, IAllergyRepository allergyRepository)
        {
            _context = context;
            Patients = patientRepository;
            Diseases = diseaseRepository;
            NCDs = ncdRepository;
            Allergies = allergyRepository;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
