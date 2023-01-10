namespace Patient.Dashboard.Models;

public class Patient
{
    public int Id { get; set; }
    public int ClinicId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
}