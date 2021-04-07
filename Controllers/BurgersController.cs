using System;
using System.Collections.Generic;
using gregslistapi.Models;
using gregslistapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace gregslistapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BurgersController : ControllerBase
    {

        private readonly BurgerService _service;

        public BurgersController(BurgerService service)
        {
            _service = service;
        }

        [HttpGet]  // GETALL
        public ActionResult<IEnumerable<Burger>> Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet("{id}")] // GETBYID
        public ActionResult<Burger> Get(int id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost] // POST
        public ActionResult<Burger> Create([FromBody] Burger newBurger)
        {
            try
            {
                return Ok(_service.Create(newBurger));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")] // PUT
        public ActionResult<Burger> Edit([FromBody] Burger editBurger, int id)
        {
            try
            {
                editBurger.Id = id;
                return Ok(_service.Edit(editBurger));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")] // DELETE
        public ActionResult<Burger> Delete(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}