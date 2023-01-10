using Microsoft.AspNetCore.Mvc;
using Patient.Dashboard.Repository;

namespace Patient.Dashboard.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClinicController : ControllerBase
{
    private readonly IDataAccess _dataAccess;
    
    public ClinicController(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }
    [HttpGet]
    public IEnumerable<Models.Clinic> Get()
    {
        return _dataAccess.GetClinics();
    }
}