using MyVetAppointment.Business.Models.Drugs;
using AutoMapper;
using MyVetAppointment.Data.Repositories;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Exceptions;

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

        public async Task<List<DrugResponse>> GetAllDrugsAsync()
        {
            var drugs = await _drugRepository.GetAllAsync(exp => true);
            return _mapper.Map<List<Drug>, List<DrugResponse>>(drugs);
        }

        public async Task<DrugResponse> AddDrugAsync(DrugRequest drug)
        {
            var drugEntity = _mapper.Map<DrugRequest, Drug>(drug);
            return _mapper.Map<Drug, DrugResponse>(await _drugRepository.AddAsync(drugEntity));
        }

        public async Task<DrugResponse> DeleteDrugAsync(Guid id)
        {
            var drug = await _drugRepository.GetFirstLazyLoad(x => x.Id == id);
            if (drug == null)
                throw new RecordNotFoundException("A drug with this id doesn't exist.");

            return _mapper.Map<Drug, DrugResponse>(await _drugRepository.DeleteAsync(drug!));
        }

        public async Task<DrugResponse> UpdateDrugAsync(DrugRequest model, Guid id)
        {
            var drugEntity = await _drugRepository.GetFirstAsync(x => x.Id == id);
            if (drugEntity == null)
                throw new RecordNotFoundException("A drug with this id doesn't exist.");

            drugEntity.Name = model.Name;
            drugEntity.Price = model.Price;
            drugEntity.TotalQuantity = model.TotalQuantity;
            drugEntity.ExpirationDate = model.ExpirationDate;
            return _mapper.Map<Drug, DrugResponse>(await _drugRepository.UpdateAsync(drugEntity));
        }
    }
}