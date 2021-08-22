using dotnet5_webapp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet5_webapp.Controllers
{   

    //definition of controller
    // api/Contact   ([controller] = name of class before the word controller
    [Route("api/[controller]")] 

    //Types and all derived types are used to serve API responses 
    // Enables API specific features like attribute routing and automatic http 400 responses if model is bad  
    [ApiController]
    public class ContactController : ControllerBase
    {

        private List<Contact> contacts = new List<Contact>
        {
            new Contact { Id=1, FirstName="Peter", LastName="Parker", NickName="Spiderman", Place="New York City"},
            new Contact { Id=2, FirstName="Tony", LastName="Stark", NickName="Ironman", Place="Long Island"}

        };


        // GET: api/<ContactController>
        [HttpGet]
        public ActionResult<IEnumerable<Contact>> Get()
        {
            
            return contacts;
            //return new string[] { "value1", "value2" };
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        //IActionResult type - multiple return types are possible (represent various HTTP codes - can send back various codes)
        public ActionResult<Contact> Get(int id)
        {
            Contact contact = contacts.FirstOrDefault(c => c.Id == id);
            if (contact==null)
            {
                return NotFound(new { Message = "Contact has not been found." });
            }
            return Ok(contact);
        }

        // POST api/<ContactController>
        [HttpPost]
        //public void Post([FromBody] string value)
        public ActionResult<IEnumerable<Contact>> Post(Contact newContact)
        {
            contacts.Add(newContact);
            return contacts;

        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
