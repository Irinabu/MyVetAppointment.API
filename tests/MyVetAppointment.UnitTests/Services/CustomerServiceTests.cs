using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UnitTests;
using MyVetAppointment.Business.Services;

namespace MyVetAppointment.UnitTests.Services
{
    class CustomerServiceTests
    {
        private readonly DITests diKernel;
        private readonly ICustomerService customerService;

        public CustomerServiceTests()
        {
            diKernel = new DITests();
            customerService = diKernel.ResolveService<ICustomerService>();
        }

    }
}
