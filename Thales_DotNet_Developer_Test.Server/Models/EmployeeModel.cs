using System.Text.Json.Serialization;

namespace Thales_DotNet_Developer_Test.Server.Models
{
    public class EmployeeModel : EmployeeDataModel
    {
        public decimal Salary { get; set; }
    }

    public class EmployeeDataModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }        
    }
}
