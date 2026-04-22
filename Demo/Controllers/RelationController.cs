using Demo.Context;
using Demo.DTOs.Employees;
using Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public RelationController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("/EmployeeV01/{id:int}")]
        public ActionResult<Employee> GetEmplyeeWithDepts([FromRoute] int id)
        {
            var emp = _dbContext.Employees
                .Include(e=>e.Department)
                .FirstOrDefault(e=> e.Id == id);

            if(emp == null)
            {
                return NotFound(new { Message = $"Employee with Id: {id} Not Found" });
            }

            return Ok(emp);
        }

        [HttpGet("/EmployeeV02/{id:int}")]
        public ActionResult<EmployeeReadDto> GetEmplyeeWithDeptsUsingDto([FromRoute] int id)
        {
            var emp = _dbContext.Employees.Include(e=>e.Department).FirstOrDefault(e => e.Id == id);
            if (emp == null)
            {
                return NotFound(new { Message = $"Employee with Id: {id} Not Found" });

            }

            var employeeDto = new EmployeeReadDto
            {
                Id = emp.Id,
                Name = emp.Name,
                Age = emp.Age,
                Salary = emp.Salary,
                DepartmentId= emp.DepartmentId,
                DepartmentName = emp.Department.Name

            };

            return Ok(employeeDto);

        }



            [HttpGet("/Depatments/{id:int}")]
        public ActionResult<Department> GetDeptsWithEmps([FromRoute] int id)
        {
            var dept = _dbContext.Departments.Include(e=>e.Employees).FirstOrDefault(e=>e.Id == id);
            if (dept == null)
            {
                return NotFound(new { Message = $"Department with Id: {id} Not Found" });
            }

            return Ok(dept);
        }
    }
}
