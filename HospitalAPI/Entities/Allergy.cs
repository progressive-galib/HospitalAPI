namespace HospitalAPI.Entities
{
    public class Allergy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PatientAllergy> PatientAllergies { get; set; }
    }
}
