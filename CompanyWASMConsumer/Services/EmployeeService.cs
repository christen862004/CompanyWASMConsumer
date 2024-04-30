
using System.Net.Http.Json;

namespace CompanyWASMConsumer.Services
{
    //API url:10.0.0.1
    public class EmployeeService : IServices<Employee>
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task Delete(int id)
        {
           await httpClient.DeleteAsync($"api/Employees/{id}");
        }

        public async Task<List<Employee>> GetAll()
        {
            List<Employee>? Emps=
                await  httpClient.GetFromJsonAsync<List<Employee>>("api/Employees");
            return Emps;
        }

        public async Task<Employee> GetByID(int id)
        {
            Employee emp=await httpClient.GetFromJsonAsync<Employee>($"api/Employees/{id}");
            return emp;
        }

        public async Task Insert(Employee item)
        {
          var response= await  httpClient.PostAsJsonAsync<Employee>("api/Employees", item);
          //response.Content.read
        }

        public async Task Update(int id, Employee item)
        {
            await httpClient.PutAsJsonAsync<Employee>($"api/Employees/{id}", item);
        }
    }
}
