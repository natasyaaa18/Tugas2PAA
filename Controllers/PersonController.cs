using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tugas2PAA.Models;

namespace Tugas2PAA.Controllers
{
    public class PersonController : Controller
    {
        private string __constr;

        public PersonController(IConfiguration configuration)
        {
            __constr = configuration.GetConnectionString("WebApiDatabase");
        }

        public IActionResult index()
        {
            return View();
        }

        //read
        [HttpGet("api/murid")]

        public ActionResult<Murid> ListPerson()
        {
            PersonContext context = new PersonContext(this.__constr);
            List<Murid> ListPerson = context.ListPerson();
            return Ok(ListPerson);
        }

        //create
        [HttpPost("api/murid/create")]
        public IActionResult CreatePerson([FromBody] Murid person)
        {
            PersonContext context = new PersonContext(this.__constr);
            context.AddPerson(person);
            return Ok("Person added successfully.");
        }

        //update
        [HttpPut("api/murid/update/{id}")]
        public IActionResult UpdatePerson(int id, [FromBody] Murid person)
        {
            person.id_person = id;
            PersonContext context = new PersonContext(this.__constr);
            context.UpdatePerson(person);
            return Ok("Person updated successfully.");
        }

        //delete
        [HttpDelete("api/murid/delete/{id}")]
        public IActionResult DeletePerson(int id)
        {
            PersonContext context = new PersonContext(this.__constr);
            context.DeletePerson(id);
            return Ok("Person deleted successfully.");
        }

    }

}