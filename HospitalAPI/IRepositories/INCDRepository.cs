using HospitalAPI.Entities;

namespace HospitalAPI.IRepositories
{
    public interface INCDRepository : IRepository<NCD>
    {
        NCD GetByName(string name);
    }
}
