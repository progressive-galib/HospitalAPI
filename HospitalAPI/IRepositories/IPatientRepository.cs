using HospitalAPI.Entities;

namespace HospitalAPI.IRepositories
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<Patient> GetPatientWithDetailsAsync(int id);
    }
}
