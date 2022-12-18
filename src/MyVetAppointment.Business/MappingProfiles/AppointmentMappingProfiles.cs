using AutoMapper;
using MyVetAppointment.Business.Models.Animal;
using MyVetAppointment.Business.Models.Appointment;
using MyVetAppointment.Business.Models.Drugs;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.Business.MappingProfiles
{

    public class AppointmentMappingProfiles : Profile
    {
        public AppointmentMappingProfiles()
        {
            CreateMap<Appointment, AppointmentResponse>();
            CreateMap<AppointmentRequest, Appointment>();
            CreateMap<Bill, BillResponse>();
            CreateMap<BillRequest, Bill>();
            CreateMap<PrescriptionDrugRequest, PrescriptionDrug>();
            CreateMap<PrescriptionDrug, PrescriptionDrugRequest>();
            CreateMap<DrugRequest, Drug>();
            CreateMap<Drug, DrugResponse>();
            CreateMap<AnimalRequest, Animal>();
            CreateMap<Animal, AnimalResponse>();
        }
    }
}