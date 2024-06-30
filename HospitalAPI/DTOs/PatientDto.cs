using HospitalAPI.Entities;

namespace HospitalAPI.DTOs
{
    public class PatientDto
    {
        public string Name { get; set; }
        public string Epilepsy { get; set; }
        public string DiseaseName { get; set; }
        public List<string> NCD { get; set; }
        public List<string> Allergy { get; set; }
    }

    public class PatientDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Epilepsy { get; set; }
        public string DiseaseName { get; set; }
        public List<string> NCD { get; set; }
        public List<string> Allergy { get; set; }
    }
}
