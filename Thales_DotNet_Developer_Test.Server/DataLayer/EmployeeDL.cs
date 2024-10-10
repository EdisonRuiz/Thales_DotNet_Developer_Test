using System.Diagnostics.CodeAnalysis;
using Thales_DotNet_Developer_Test.Server.Models;

namespace Thales_DotNet_Developer_Test.Server.DataLayer
{
    public class EmployeeDL : IEmployeeDL
    {
        private string _urlApi;
        private readonly IConfiguration _configRoot;

        public EmployeeDL(IConfiguration configRoot)
        {
            _configRoot = configRoot;
            _urlApi = _configRoot[Enums.Url] ?? string.Empty;
        }

        public async Task<IList<EmployeeModel>> GetEmployeeById(int idEmployee)
        {
            string url = GetUrlMethod(true,idEmployee);
            return await GetResponseApi(url);
        }

        public async Task<IList<EmployeeModel>> GetAllEmployees()
        {
            string url = GetUrlMethod(false,Enums.IdDefault);
            return await GetResponseApi(url);
        }

        private string GetUrlMethod(bool isSearchbyId, int idEmployee)
        {
            int noRecords = (int)default;
            string records = _configRoot[Enums.NameRecordLimit] ?? string.Empty;

            if (!String.IsNullOrEmpty(_urlApi) && !String.IsNullOrEmpty(records))
                noRecords = int.Parse(records);

            string url = String.Format(_urlApi, (!isSearchbyId ? noRecords : Enums.IdDefault), idEmployee);
            return url;
        }

        private async Task<List<EmployeeModel>> GetResponseApi(string url)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<List<EmployeeModel>>();
                if (content != null)
                    return content;
            }
            return new List<EmployeeModel>();
        }
    }
}
