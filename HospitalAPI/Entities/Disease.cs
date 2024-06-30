﻿

namespace HospitalAPI.Entities

{
    public class Disease
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}
