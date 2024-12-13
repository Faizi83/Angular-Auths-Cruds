using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using work.Models;
using work.Repositries.User;
using work.Dtos;

namespace work.Services.User
{
    public interface IEmployeeServices
    {
        Task<List<Employee>> GetAllEmployees();

        Task<Employee> GetEmployeById(int id);

        Task<int> AddEmployeeAsync(EmployeeDto model);
        Task<int> RemoveEmployee(int id);
        Task<int> UpdateEmployee(int id, EmployeeDto updateEmployee);

    


    }
}
