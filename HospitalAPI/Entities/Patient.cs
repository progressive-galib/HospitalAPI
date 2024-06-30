namespace HospitalAPI.Entities

{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EpilepsyStatus Epilepsy { get; set; }
        public int DiseaseId { get; set; }
        public Disease Disease { get; set; }
        public ICollection<PatientNCD> PatientNCDs { get; set; }
        public ICollection<PatientAllergy> PatientAllergies { get; set; }
    }

    public enum EpilepsyStatus
    {
        No,
        Yes
    }
}

