using AutoMapper;
using MediatR;
using MyVetAppointment.API.Queries;
using MyVetAppointment.Business.Models.Animal;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Repositories;

namespace MyVetAppointment.API.Handlers
{
    public class GetCustomerAnimalsQueryHandler : IRequestHandler<GetCustomerAnimalsQuery, List<AnimalResponse>>
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;

        public GetCustomerAnimalsQueryHandler(ICustomerRepository customerRepository, IAnimalRepository animalRepository, IMapper mapper)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
        }

        public async Task<List<AnimalResponse>> Handle(GetCustomerAnimalsQuery request, CancellationToken cancellationToken)
        {

            var animals = await _animalRepository.GetAllLazyLoad(x => x.Owner!.Id == Guid.Parse(request.Id!));
            return _mapper.Map<List<Animal>, List<AnimalResponse>>(new List<Animal>(animals));
        }


    }
}
