using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Database;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly DatabaseContext dbContext;

        public EmployeeController(DatabaseContext _dbContext)
        {
            dbContext = _dbContext;   
        }



        //post 
        [HttpPost("create")]
        public ActionResult<Employee> create( [FromBody] Employee employee) 
        {

            if(employee == null)
            {
                return NoContent();
            }
            else
            {
                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();
                return Ok(employee);
            }
        }

        [HttpGet("GetAll")]
        public ActionResult<Employee> getAll()
        {
            var emp = dbContext.Employees.ToList();
            if(emp != null) 
            {
                return Ok(emp);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public ActionResult Get(int id)
        {
            var empl = dbContext.Employees.FirstOrDefault(e => e.Id == id);
            if(empl != null)
            {
                return Ok(empl);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public ActionResult<Employee> update([FromRoute] int id, [FromBody] Employee employee) 
        {
            var empl = dbContext.Employees.FirstOrDefault(x=> x.Id == id);

            empl.Name = employee.Name;
            empl.EmailID = employee.EmailID;
            empl.Password = employee.Password;

            dbContext.Employees.Update(empl);
            dbContext.SaveChanges();
            return Ok(empl.Name + "Updated Successfully !!!");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult<Employee> delete(int id)
        {
            var empl = dbContext.Employees.FirstOrDefault(x => x.Id == id);
            if (empl == null)
            {
                return BadRequest();
            }
            else
            {
                dbContext.Employees.Remove(empl);
                dbContext.SaveChanges();
                return Ok("deleted Successfully ");
            }
        }

    }
}
