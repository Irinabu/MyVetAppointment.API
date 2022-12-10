using MyVetAppointment.Business.Models.Drugs;

namespace MyVetAppointment.Business.Services;

public interface IDrugService
{
    public Task<DrugResponse> AddDrugAsync(DrugRequest drug);
    public Task<DrugResponse> DeleteDrugAsync(Guid id);
    public Task<List<DrugResponse>> GetAllDrugsAsync();
    public Task<DrugResponse> UpdateDrugAsync(DrugRequest model, Guid id);
}