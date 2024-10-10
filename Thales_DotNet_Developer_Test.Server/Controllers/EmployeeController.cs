using Microsoft.AspNetCore.Mvc;
using Thales_DotNet_Developer_Test.Server.BusinessLayer;

namespace Thales_DotNet_Developer_Test.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
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
