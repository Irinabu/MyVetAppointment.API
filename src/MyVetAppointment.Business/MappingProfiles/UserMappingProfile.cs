using AutoMapper;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.Data.Entities;


namespace MyVetAppointment.Business.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, RegisterRequest>();
            CreateMap<Customer, RegisterRequest>();
            CreateMap<VetDoctor, RegisterRequest>();

            CreateMap<RegisterRequest, VetDoctor>();
            CreateMap<RegisterRequest, Customer>();
            CreateMap<RegisterRequest, User>();

        }
    }
}
