using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Patient.Dashboard.Repository;
using Moq;
using Patient.Dashboard.Api.Controllers;

namespace Patient.Dashboard.Api.Tests;

public class PatientControllerTests
{
    [Fact]
    public async Task GetRetrievesExpectedPatients()
    {
        var expectedPatients = new List<Models.Patient>
        {
            new Models.Patient
            {
                Id = 1,
                ClinicId = 1,
                FirstName = "Harriott",
                LastName = "Wansbury",
                DateOfBirth = DateTime.Parse("1961-10-16")
            },
            new Models.Patient
            {
                Id = 2,
                ClinicId = 1,
                FirstName = "Glennis",
                LastName = "Eustis",
                DateOfBirth = DateTime.Parse("1985-04-08")
            },
            new Models.Patient
            {
                Id = 1,
                ClinicId = 2,
                FirstName = "Emlynn",
                LastName = "Tompkin",
                DateOfBirth = DateTime.Parse(",1964-10-02")
            },
            new Models.Patient
            {
                Id = 2,
                ClinicId = 2,
                FirstName = "Kenyon",
                LastName = "Domleo",
                DateOfBirth = DateTime.Parse("1960-05-24")
            }
        };
        var dataAccess = new Mock<IDataAccess>();
        dataAccess.Setup(_ => _.GetPatients()).Returns(expectedPatients);

        var controller = new PatientController(dataAccess.Object);
       
        var response = controller.Get();
        
        response.Should().BeEquivalentTo(expectedPatients);
    }
}