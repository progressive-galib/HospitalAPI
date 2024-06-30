namespace HospitalAPI.IRepositories
{
    public interface IUnitOfWork
    {
        IPatientRepository Patients { get; }
        IDiseaseRepository Diseases { get; }
        INCDRepository NCDs { get; }
        IAllergyRepository Allergies { get; }
        Task<int> CompleteAsync();
    }
}
