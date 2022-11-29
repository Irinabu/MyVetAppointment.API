using AutoMapper;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.Data.Entities;


namespace MyVetAppointment.Business.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, RegisterResponse>();
            CreateMap<Customer, RegisterResponse>();
            CreateMap<VetDoctor, RegisterResponse>(); 
            CreateMap<Customer, CustomerResponse>();
            CreateMap<VetDoctor, VetDoctorResponse>();

            CreateMap<RegisterRequest, VetDoctor>();
            CreateMap<RegisterRequest, Customer>();
            CreateMap<RegisterRequest, User>();
            
        }
    }
}
