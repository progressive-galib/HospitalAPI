using AutoMapper;
using HospitalAPI.DTOs;
using HospitalAPI.Entities;

namespace HospitalAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Patient, PatientDetailsDto>()
                .ForMember(dest => dest.DiseaseName, opt => opt.MapFrom(src => src.Disease.Name))
                .ForMember(dest => dest.NCD, opt => opt.MapFrom(src => src.PatientNCDs.Select(pn => pn.NCD.Name).ToList()))
                .ForMember(dest => dest.Allergy, opt => opt.MapFrom(src => src.PatientAllergies.Select(pa => pa.Allergy.Name).ToList()));

            CreateMap<Disease, DiseaseDetailsDto>();
            CreateMap<NCD, NCDDetailsDto>();
            CreateMap<Allergy, AllergyDetailsDto>();
        }
    }
}
