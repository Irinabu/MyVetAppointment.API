﻿namespace MyVetAppointment.Business.Models.User;

public class GetUserResponse
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}