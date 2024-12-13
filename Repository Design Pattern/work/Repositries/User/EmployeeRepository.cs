using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using work.DbConext;
using work.Models;
using work.Dtos;

namespace work.Repositries.User
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            this._context = context;

        }

        public async Task<int> Register(Register model)
        {
            await _context.Registers.AddAsync(model);
            return await _context.SaveChangesAsync();
          
        }

        public async Task<Employee> GetEmployeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return employee;
        }

   


        public async Task<int> AddEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return employee.Id;

        }

        public async Task<int> UpdateEmployee(Employee emp)
        {

            _context.Employees.Update(emp);
            return await _context.SaveChangesAsync();


        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var employee = await _context.Employees.Where(x => x.is_deleted == false).ToListAsync();

            return employee;


        }

        public async Task<int> RemoveEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            employee.is_deleted = true;

            return await _context.SaveChangesAsync();


        }


    }
}
