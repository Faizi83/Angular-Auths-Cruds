using Microsoft.AspNetCore.Mvc;
using work.Models;
using work.Dtos;
namespace work.Repositries.User
{
    public interface IEmployeeRepository
    {

        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeById(int id);
        Task<int> AddEmployee(Employee employee);
        Task<int> UpdateEmployee(Employee emp);

        Task<int> RemoveEmployee(int id);

        Task<int> Register(Register model);

     
        //Task<Employee> GetById(int id);
        //Task<IEnumerable<Employee>> GetAll();
        //Task<Employee> UpdateEmployee(Employee employee);
        //Task<Employee> DeleteEmployee(int id);


    }
}
