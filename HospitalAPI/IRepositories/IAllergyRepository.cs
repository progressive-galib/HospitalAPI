using HospitalAPI.Entities;

namespace HospitalAPI.IRepositories
{
    public interface IAllergyRepository : IRepository<Allergy>
    {
        Allergy GetByName(string name);
    }
}
