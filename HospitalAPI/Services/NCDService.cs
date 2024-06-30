using AutoMapper;
using HospitalAPI.DTOs;
using HospitalAPI.Entities;
using HospitalAPI.IRepositories;

namespace HospitalAPI.Services
{
    public class NCDService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NCDService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddNCDAsync(NCDDto ncdDto)
        {
            var ncd = new NCD
            {
                Name = ncdDto.Name
            };

            await _unitOfWork.NCDs.AddAsync(ncd);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<NCDDetailsDto> GetNCDAsync(int id)
        {
            var ncd = await _unitOfWork.NCDs.GetByIdAsync(id);

            if (ncd == null)
            {
                return null;
            }

            return _mapper.Map<NCDDetailsDto>(ncd);
        }
    }
}
