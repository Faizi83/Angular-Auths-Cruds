using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using work.Models;
using work.Utilities;
using work.Repositries.User;
using work.Services.User;
using work.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace work.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _userservices;
        private readonly AuthServices _authservices;
        public EmployeeController(IEmployeeServices userservices, AuthServices authservices)
        {
            _userservices = userservices;
            _authservices = authservices;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(Register model)
        {
            try
            {
                var result = await _authservices.Register(model);
                return Ok(new { Message = "User Registered Successfully" });
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);

            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            try
            {
                var result = await _authservices.Login(email, password);
                return Ok(new { Message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[Authorize]
        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var result = await _userservices.GetAllEmployees();
                return Ok(new { Message = "All Employees:", Result = result });
            }

            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);

            }
        }

        [HttpGet("GetEmployeById")]
        public async Task<IActionResult> GetEmployeById(int id)
        {
            try
            {
                var result = await _userservices.GetEmployeById(id);
                return Ok(new { Message = "Employee:", Result = result });

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee(EmployeeDto employee)
        {
            try
            {
                var result = await _userservices.AddEmployeeAsync(employee);
                return Ok(new { Message = "User Added", Result = result });
            }

            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);

            }



        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeDto updateEmployee)
        {
            try
            {
                var result = await _userservices.UpdateEmployee(id, updateEmployee);
                return Ok(new { Message = "User Updated", Result = result });
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }


        }

        [HttpPost("RemoveEmployee")]
        public async Task<IActionResult> RemoveEmployee(int id)
        {
            try
            {
                var result = await _userservices.RemoveEmployee(id);
                return Ok(new { Message = "User Removed", Result = result });
            }

            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);

            }



        }


    }

}