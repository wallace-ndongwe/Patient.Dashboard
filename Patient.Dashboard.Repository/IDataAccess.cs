namespace Patient.Dashboard.Repository;

public interface IDataAccess
{
    IEnumerable<Models.Patient> GetPatients();
    IEnumerable<Models.Clinic> GetClinics();
}