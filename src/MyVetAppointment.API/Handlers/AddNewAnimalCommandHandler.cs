using AutoMapper;
using MediatR;
using MyVetAppointment.API.Commands;
using MyVetAppointment.API.Queries;
using MyVetAppointment.Business.Models.Animal;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Repositories;

namespace MyVetAppointment.API.Handlers
{
    public class AddNewAnimalCommandHandler : IRequestHandler<AddNewAnimalCommand, AnimalResponse>
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public AddNewAnimalCommandHandler(IAnimalRepository animalRepository, ICustomerRepository customerRepository, IMapper mapper)
        {
            _animalRepository = animalRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<AnimalResponse> Handle(AddNewAnimalCommand request, CancellationToken cancellationToken)
        {
            var animalEntity = _mapper.Map<AnimalRequest, Animal>(request.AnimalRequest!);
            var user = await _customerRepository.GetFirstAsync(x => x.Id == Guid.Parse(request.UserId!));
            animalEntity.Owner = user;
            var dbAnimal = await _animalRepository.AddAsync(animalEntity);
            return _mapper.Map<Animal, AnimalResponse>(dbAnimal);
        }
    }
}
