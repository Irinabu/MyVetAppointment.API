using AutoMapper;
using MyVetAppointment.Business.Models.Animal;
using MyVetAppointment.Business.Models.Appointment;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Repositories;

namespace MyVetAppointment.Business.Services.Implementations
{

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IAnimalRepository animalRepository,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _animalRepository = animalRepository;
            _mapper = mapper;
        }

        public bool DeleteCustomer(string id)
        {
            var user = _customerRepository.GetFirstAsync(u => u.Id == Guid.Parse(id));
            if (user == null)
                return false;
            _customerRepository.DeleteAsync(user.Result);
            _customerRepository.SaveChangesAsync();
            return true;
        }

        public List<Customer> GetAllAsync()
        {
            return _customerRepository.GetAllAsync(exp => true).Result;
        }


        public Customer GetCustomerByEmailAsync(string email)
        {
            return _customerRepository.GetFirstAsync(u => u.Email == email).Result;
        }

        public async Task<AnimalResponse> AddAnimalAsync(AnimalRequest animal, User user)
        {
            var animalEntity = _mapper.Map<AnimalRequest, Animal>(animal);
            animalEntity.Owner = (Customer)user;
            return _mapper.Map<Animal, AnimalResponse>(await _animalRepository.AddAsync(animalEntity));
        }

        public async Task<List<AnimalResponse>?> GetUserAnimals(User user)
        {
            //var type = user.GetType().ToString().Split(".");
            //var role = type[type.Length - 1];
            //if (role == "Customer")
            //{
            //    var appointments =
            //        await _appointmentRepository.GetAllLazyLoad(x => x.Customer!.Id == user.Id, x => x.VetDoctor!,
            //            x => x.Customer!, x => x.Bill, x => x.Bill.PrescriptionDrugs);
            //    return _mapper.Map<List<Appointment>, List<AppointmentResponse>>(appointments.ToList());
            //}

            var animals = await _animalRepository.GetAllLazyLoad(x =>x.Owner.Id==user.Id);
            return _mapper.Map<List<Animal>, List<AnimalResponse>>(animals.ToList());



            //return null;
        }

    }
}