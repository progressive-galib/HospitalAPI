namespace HospitalAPI.Entities
{
    public class NCD
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PatientNCD> PatientNCDs { get; set; }
    }
}
