using MyVetAppointment.Business.Models.Drugs;
using AutoMapper;
using MyVetAppointment.Data.Repositories;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.Business.Services.Implementations
{
    public class DrugService : IDrugService
    {
        private readonly IDrugRepository _drugRepository;
        private readonly IMapper _mapper;

        public DrugService(IDrugRepository drugRepository, IMapper mapper)
        {
            _drugRepository = drugRepository;
            _mapper = mapper;
        }

        public async Task<DrugResponse> AddDrugAsync(DrugRequest drug)
        {
            var drugEntity = _mapper.Map<DrugRequest, Drug>(drug);
            return _mapper.Map<Drug, DrugResponse>(await _drugRepository.AddAsync(drugEntity));
        }
    }
}