using AutoMapper;
using Microsoft.Extensions.Configuration;
using Thales_DotNet_Developer_Test.Server.BusinessLayer;
using Thales_DotNet_Developer_Test.Server.DataLayer;
using Thales_DotNet_Developer_Test.Server.Models;
using Thales_DotNet_Developer_Test.Server.Models.Profiles;

namespace Thales_DotNet_Developer_Test.ServerTests
{
    public class EmployeeBLTesting
    {
        private readonly IEmployeeBL _service;
        private readonly IEmployeeDL _employeeDL;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configRoot;

        public EmployeeBLTesting()
        {
            //MOCK AppSettings
            var inMemorySettings = new Dictionary<string, string> {
                {"ApiSettings:UrlApi", "https://hub.dummyapis.com/employee?noofRecords={0}&idStarts={1}"},
                {"ApiSettings:RecordLimit", "50"},
                //...populate as needed for the test
            };

            _configRoot = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build(); ;
            //MOCK mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EmployeeProfile()); 
            });

            _mapper = mockMapper.CreateMapper();
            _employeeDL = new EmployeeDL(_configRoot);
            _service = new EmployeeBL(_employeeDL, _mapper);
        }

        [Fact]
        public async void Get_OK()
        {
            var result = await _service.GetAllEmployees();
            Assert.IsType<List<EmployeeDTOModel>>(result);
        }

        [Fact]
        public async void Get_Quantity()
        {
            var result = await _service.GetAllEmployees();
            var employees = Assert.IsType<List<EmployeeDTOModel>>(result);
            Assert.True(employees.Count > 0);
        }

        [Fact]
        public async void Get_OKById()
        {
            //Arrange
            int idEmployee = 1;

            //Act
            var result = await _service.GetEmployeeById(idEmployee);

            //Assert
            Assert.IsType<List<EmployeeDTOModel>>(result);
        }

        [Fact]
        public async void Get_QuantityById()
        {
            //Arrange
            int idEmployee = 1;

            //Act
            var result = await _service.GetEmployeeById(idEmployee);

            //Assert
            var employees = Assert.IsType<List<EmployeeDTOModel>>(result);
            Assert.True(employees.Count == 1);
        }
    }
}