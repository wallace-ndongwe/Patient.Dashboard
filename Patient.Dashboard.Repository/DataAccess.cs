using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Patient.Dashboard.Models;

namespace Patient.Dashboard.Repository;

public class DataAccess: IDataAccess
{
    public IEnumerable<Models.Patient> GetPatients()
    {
        var clinic1Patients = GetRecords<Models.Patient>("patients-1.csv");
        var clinic2Patients = GetRecords<Models.Patient>("patients-2.csv");
        return clinic1Patients.Concat(clinic2Patients);
    }

    public IEnumerable<Clinic> GetClinics()
    {
        return GetRecords<Clinic>("clinics.csv");
    }

    private IEnumerable<T> GetRecords<T>(string filePath)
    {
        using (var reader = new StreamReader($"bin\\Debug\\net6.0\\Data\\{filePath}"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<PatientMap>();
            csv.Context.RegisterClassMap<ClinicMap>();
            return csv.GetRecords<T>().ToList();
        }
    }
}

public sealed class PatientMap : ClassMap<Models.Patient>
{
    public PatientMap()
    {
        Map(m => m.Id).Name("id");
        Map(m => m.ClinicId).Name("clinic_id");
        Map(m => m.FirstName).Name("first_name");
        Map(m => m.LastName).Name("last_name");
        Map(m => m.DateOfBirth).Name("date_of_birth");
    }
}

public sealed class ClinicMap : ClassMap<Clinic>
{
    public ClinicMap()
    {
        Map(m => m.Id).Name("id");
        Map(m => m.Name).Name("name");
    }
}