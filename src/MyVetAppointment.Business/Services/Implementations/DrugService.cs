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
            return _mapper.Map<Drug, DrugResponse>(await _drugRepository.DeleteAsync(drug));
        }

        public async Task<DrugResponse> UpdateDrugAsync(DrugRequest drug, Guid id)
        {
            var drugEntity = await _drugRepository.GetFirstAsync(x => x.Id == id);
            drugEntity.Name = drug.Name;
            drugEntity.Price = drug.Price;
            drugEntity.TotalQuantity = drug.TotalQuantity;
            drugEntity.ExpirationDate = drug.ExpirationDate;
            return _mapper.Map<Drug, DrugResponse>(await _drugRepository.UpdateAsync(drugEntity));
        }
    }
}