using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{

    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PipeController : ControllerBase
    {
        private static readonly List<Pipe> pipes = new List<Pipe>()
        {
            new Pipe { Id= 1, Name ="Pipe1" },
            new Pipe { Id= 2, Name ="Pipe2"}

        };
        // GET: api/<PipeController>
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(pipes);
        }

        // GET api/<PipeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pipe = pipes.Where(x => x.Id == id).FirstOrDefault();

            if (pipe is null)
            {
                return NotFound();
            }
            return Ok(pipe);
        }

        // POST api/<PipeController>
        [HttpPost]
        public IActionResult Post([FromBody] string name)
        {
            var radom = new Random();
            var id = radom.Next(1, 100);
            pipes.Add(new Pipe { Name = name, Id = id });

            return Ok();
        }

        // PUT api/<PipeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string name)
        {
            var pipe = pipes.Where(x => x.Id == id).FirstOrDefault();

            if (pipe is null)
            {
                return NotFound();
            }

            pipe.Name = name;
            return Ok(pipe);

        }

        // DELETE api/<PipeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pipe = pipes.Where(x => x.Id == id).FirstOrDefault();

            if (pipe is null)
            {
                return NotFound();
            }

            pipes.Remove(pipe);

            return Ok();
        }
    }
}
