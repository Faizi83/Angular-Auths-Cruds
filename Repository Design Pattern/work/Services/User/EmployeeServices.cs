using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using work.Models;
using work.Utilities;
using work.Repositries.User;
using work.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace work.Services.User
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository _userRepository;
      

        public EmployeeServices(IEmployeeRepository userRepository)
        {
            this._userRepository = userRepository;

        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var employee = await _userRepository.GetAllEmployees();
            return employee;

        }

        public async Task<Employee> GetEmployeById(int id)
        {
            var employee = await _userRepository.GetEmployeById(id);

            return employee;
        }
        public async Task<int> AddEmployeeAsync(EmployeeDto model)
        {
            var emp = new Employee
            {
                Name = model.Name,
                Department = model.Department,
                Age = model.Age,

            };
            return await _userRepository.AddEmployee(emp);

        }

        public async Task<int> UpdateEmployee(int id, EmployeeDto updateEmployee)
        {
            var emp = await _userRepository.GetEmployeById(id);
            emp.Name = updateEmployee.Name;
            emp.Age = updateEmployee.Age;
            emp.Department = updateEmployee.Department;


            return await _userRepository.UpdateEmployee(emp);


        }


        public async Task<int> RemoveEmployee(int id)
        {
            return await _userRepository.RemoveEmployee(id);

        }



    }
}
