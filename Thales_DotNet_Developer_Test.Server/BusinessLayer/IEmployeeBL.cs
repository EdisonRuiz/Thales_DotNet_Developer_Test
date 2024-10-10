using Thales_DotNet_Developer_Test.Server.Models;

namespace Thales_DotNet_Developer_Test.Server.BusinessLayer
{
    public interface IEmployeeBL
    {
        public Task<IList<EmployeeDTOModel>> GetAllEmployees();
        public Task<IList<EmployeeDTOModel>> GetEmployeeById(int idEmployee);
    }
}
