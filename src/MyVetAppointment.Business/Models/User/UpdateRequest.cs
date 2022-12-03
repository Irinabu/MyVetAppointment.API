namespace MyVetAppointment.Business.Models.User;

public class UpdateRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
}