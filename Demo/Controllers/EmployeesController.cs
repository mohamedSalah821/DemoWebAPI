using Demo.Context;
using Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public EmployeesController(AppDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public ActionResult<List<Employee>> GetAll()
        {
            var allemps = _db.Employees.ToList();
            return Ok(allemps);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Employee> GetById(int id)
        {
            var empById = _db.Employees.Find(id);
            if(empById == null)
            {
                return NotFound(new { Message = $"Emplpyee with id = {id} Not found :("});
            }
            return Ok(empById);
        }

        [HttpGet("{name:alpha}")]
        public ActionResult<Employee> GetByName(string name)
        {
            var empByName = _db.Employees.FirstOrDefault(e => e.Name == name);
            if(empByName == null)
            {
                return NotFound(new { Message = $"Emplpyee with name = {name} Not found :(" });

            }

            return Ok(empByName);
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            _db.Employees.Add(employee);
            _db.SaveChanges();

            //return Created();
            //return Created("Test" , employee);
            return  CreatedAtAction("GetById" , new {id = employee.Id} ,employee);



        }

        [HttpPut("{id:int}")]
        public ActionResult Update([FromRoute] int id,[FromBody]Employee employee)
        {
            if(employee is null)
            {
                return BadRequest();
            }

            if(id != employee.Id )
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var empToUpdated = _db.Employees.FirstOrDefault(e => e.Id == id);

            if (empToUpdated == null)
            {
                return BadRequest();
            }

            empToUpdated.Name = employee.Name;
            empToUpdated.Salary= employee.Salary;
            empToUpdated.Age = employee.Age;

            _db.SaveChanges();

            return Ok(empToUpdated);

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var empToDeleted = _db.Employees.FirstOrDefault(e=>e.Id == id);
            if(empToDeleted == null)
            {
                //404
                return NotFound();
            }

            _db.Employees.Remove(empToDeleted);
            _db.SaveChanges();
            return NoContent();

        }


    }
}
