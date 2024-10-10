using Thales_DotNet_Developer_Test.Server.Models;

namespace Thales_DotNet_Developer_Test.Server.DataLayer
{
    public interface IEmployeeDL
    {
        public Task<IList<EmployeeModel>> GetAllEmployees();
        public Task<IList<EmployeeModel>> GetEmployeeById(int idEmployee);

    }
}
