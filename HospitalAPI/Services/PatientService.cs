using AutoMapper;
using HospitalAPI.DTOs;
using HospitalAPI.Entities;
using HospitalAPI.IRepositories;

namespace HospitalAPI.Services
{
    public class PatientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddPatientAsync(PatientDto patientDto)
        {
            var disease = _unitOfWork.Diseases.GetByName(patientDto.DiseaseName);

            if (disease == null)
            {
                throw new Exception("Disease not found");
            }

            var patient = new Patient
            {
                Name = patientDto.Name,
                Epilepsy = Enum.Parse<EpilepsyStatus>(patientDto.Epilepsy),
                DiseaseId = disease.Id
            };

            if (patientDto.NCD != null)
            {
                foreach (var ncdName in patientDto.NCD)
                {
                    var ncd = _unitOfWork.NCDs.GetByName(ncdName);
                    if (ncd != null)
                    {
                        patient.PatientNCDs.Add(new PatientNCD { Patient = patient, NCD = ncd });
                    }
                }
            }

            if (patientDto.Allergy != null)
            {
                foreach (var allergyName in patientDto.Allergy)
                {
                    var allergy = _unitOfWork.Allergies.GetByName(allergyName);
                    if (allergy != null)
                    {
                        patient.PatientAllergies.Add(new PatientAllergy { Patient = patient, Allergy = allergy });
                    }
                }
            }

            await _unitOfWork.Patients.AddAsync(patient);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<PatientDetailsDto> GetPatientAsync(int id)
        {
            var patient = await _unitOfWork.Patients.GetPatientWithDetailsAsync(id);

            if (patient == null)
            {
                return null;
            }

            return _mapper.Map<PatientDetailsDto>(patient);
        }
    }
}
