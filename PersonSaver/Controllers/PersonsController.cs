using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonSaver.Models;
using PersonSaver.Repositories;

namespace PersonSaver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        IPersonsRepository _personsRepository;
        ILogger<PersonsController> _logger;
        
        public PersonsController(IPersonsRepository personsRepository,
                                 ILogger<PersonsController> logger) {

            _personsRepository = personsRepository;
            _logger = logger;
        }
        
        // GET api/persons
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return Ok(_personsRepository.Get());
        }

        // GET api/persons/5
        [HttpGet("{id}", Name = "GetPerson")]
        public ActionResult<string> Get(string id)
        {
            return Ok(_personsRepository.Get(id));
        }

        // POST api/persons
        [HttpPost]
        public IActionResult Post([FromBody] string name)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                var id = Guid.NewGuid().ToString();
                var newPerson = new Person { Id = id, Name = name };
                _personsRepository.Add(newPerson);
                return CreatedAtRoute("GetPerson", new { Id = id }, newPerson);
            }
            // This can be a better handler
            catch (Exception ex) {
                _logger.LogError(ex, "Unable to create request: Person", null);
                return StatusCode(500);
            }
        }

        // PUT api/persons/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Person person)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {
                _personsRepository.Update(person);
                return Ok();
            }
            // This can be a better handler
            catch (Exception ex) {
                _logger.LogError(ex, "Unable to create request: Person", null);
                return StatusCode(500);
            }
        }
    }
}
