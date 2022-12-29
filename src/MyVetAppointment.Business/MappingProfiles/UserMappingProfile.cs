using AutoMapper;
using MyVetAppointment.Business.Models;
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

            CreateMap<UpdateUserResponse, Customer>();
            CreateMap<Customer, UpdateUserResponse>();
            CreateMap<UpdateUserRequest, Customer>();
            CreateMap<Customer, UpdateUserRequest>();
            CreateMap<UpdateUserResponse, VetDoctor>();
            CreateMap<VetDoctor, UpdateUserResponse>();
            CreateMap<UpdateUserRequest, VetDoctor>();
            CreateMap<VetDoctor, UpdateUserRequest>();
        }
    }
}