using MyVetAppointment.Business.Models.Drugs;

namespace MyVetAppointment.Business.Services;

public interface IDrugService
{
    public Task<DrugResponse> AddDrugAsync(DrugRequest drug);

}