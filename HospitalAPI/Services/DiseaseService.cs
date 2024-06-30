using AutoMapper;
using HospitalAPI.DTOs;
using HospitalAPI.Entities;
using HospitalAPI.IRepositories;

namespace HospitalAPI.Services
{
    public class DiseaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DiseaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddDiseaseAsync(DiseaseDto diseaseDto)
        {
            var disease = new Disease
            {
                Name = diseaseDto.Name
            };

            await _unitOfWork.Diseases.AddAsync(disease);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<DiseaseDetailsDto> GetDiseaseAsync(int id)
        {
            var disease = await _unitOfWork.Diseases.GetByIdAsync(id);

            if (disease == null)
            {
                return null;
            }

            return _mapper.Map<DiseaseDetailsDto>(disease);
        }
    }
}
