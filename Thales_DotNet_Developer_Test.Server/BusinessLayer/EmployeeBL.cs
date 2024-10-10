using AutoMapper;
using Thales_DotNet_Developer_Test.Server.DataLayer;
using Thales_DotNet_Developer_Test.Server.Models;

namespace Thales_DotNet_Developer_Test.Server.BusinessLayer
{
    public class EmployeeBL : IEmployeeBL
    {
        private readonly IEmployeeDL _employeeDL;
        private readonly IMapper _mapper;

        public EmployeeBL(IEmployeeDL employeeDL,
            IMapper mapper) 
        {
            _employeeDL = employeeDL;
            _mapper = mapper;
        }
        public async Task<IList<EmployeeDTOModel>> GetEmployeeById(int idEmployee)
        {
            IList<EmployeeDTOModel> response = new List<EmployeeDTOModel>();
            IList<EmployeeModel> employees = await _employeeDL.GetEmployeeById(idEmployee);
            employees.ToList().ForEach(x => response.Add(_mapper.Map<EmployeeDTOModel>(x)));
            return response;
        }

        public async Task<IList<EmployeeDTOModel>> GetAllEmployees()
        {
            IList<EmployeeDTOModel> response = new List<EmployeeDTOModel>();
            IList<EmployeeModel> employees = await _employeeDL.GetAllEmployees();
            employees.ToList().ForEach(x => response.Add(_mapper.Map<EmployeeDTOModel>(x)));
            return response;
        }
    }
}
