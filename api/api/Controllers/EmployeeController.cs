using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public static readonly string[] Employees = new[] { "Ruth Hognestad", "Anna Frankenstein", "Morten Harket", "Tina Tuna" };

        // GET: api/<EmployeeController>
        [HttpGet("employee")]
        public IActionResult GetEmployee()
        {
            return Ok(Employees);
        }

        [HttpGet("total-employees")]
        public IActionResult TotalEmployees()
        {
            return Ok(Employees.Length);
        }
    }
}
