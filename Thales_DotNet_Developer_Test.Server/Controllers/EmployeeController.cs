using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Thales_DotNet_Developer_Test.Server.BusinessLayer;
using Thales_DotNet_Developer_Test.Server.DataLayer;
using Thales_DotNet_Developer_Test.Server.Models;

namespace Thales_DotNet_Developer_Test.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<EmployeeController> _logger;

        private readonly IEmployeeBL _employeeBL;

        public EmployeeController(ILogger<EmployeeController> logger,
            IEmployeeBL employeeBL)
        {
            _logger = logger;
            _employeeBL = employeeBL;
        }


        [HttpGet]        
        public async Task<IActionResult> GetAllAsync() => Ok(await _employeeBL.GetAllEmployees());


        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int idEmployee) => Ok(await _employeeBL.GetEmployeeById(idEmployee));
    }
}
