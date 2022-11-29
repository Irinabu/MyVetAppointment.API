using Microsoft.Identity.Client;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Persistence;
using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MyVetAppointment.Data.Repositories.Implementations
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(DatabaseContext context) : base(context)
        {
            
        }
    }
}
