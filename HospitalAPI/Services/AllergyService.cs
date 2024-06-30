using AutoMapper;
using HospitalAPI.DTOs;
using HospitalAPI.Entities;
using HospitalAPI.IRepositories;

namespace HospitalAPI.Services
{
    public class AllergyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AllergyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAllergyAsync(AllergyDto allergyDto)
        {
            var allergy = new Allergy
            {
                Name = allergyDto.Name
            };

            await _unitOfWork.Allergies.AddAsync(allergy);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<AllergyDetailsDto> GetAllergyAsync(int id)
        {
            var allergy = await _unitOfWork.Allergies.GetByIdAsync(id);

            if (allergy == null)
            {
                return null;
            }

            return _mapper.Map<AllergyDetailsDto>(allergy);
        }
    }
}
