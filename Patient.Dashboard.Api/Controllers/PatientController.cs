using Microsoft.AspNetCore.Mvc;
using Patient.Dashboard.Repository;

namespace Patient.Dashboard.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase
{
    private readonly IDataAccess _dataAccess;
    
    public PatientController(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }
    [HttpGet]
    public IEnumerable<Models.Patient> Get()
    {
        return _dataAccess.GetPatients();
    }
}