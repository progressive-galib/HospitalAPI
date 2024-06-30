using HospitalAPI.Entities;

namespace HospitalAPI.IRepositories
{
    public interface IDiseaseRepository : IRepository<Disease>
    {
        Disease GetByName(string name);
    }
}
