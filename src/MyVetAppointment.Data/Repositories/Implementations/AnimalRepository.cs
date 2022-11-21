using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Persistence;

namespace MyVetAppointment.Data.Repositories.Implementations;

public class AnimalRepository : BaseRepository<Animal>, IAnimalRepository
{
    public AnimalRepository(DatabaseContext context) : base(context)
    {
    }
}
