﻿using MyVetAppointment.Business.Models.Appointment;

namespace MyVetAppointment.Business.Services;

public interface IBillService
{
    public Task<BillResponse> AddBillAsync(BillRequest bill, Guid idAppointment);
}