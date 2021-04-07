using System;
using System.Collections.Generic;
using gregslistapi.Models;
using gregslistapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace gregslistapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FriesController : ControllerBase
    {

        private readonly FriesService _service;

        public FriesController(FriesService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Fries>> Get()
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



        [HttpGet("{id}")]
        public ActionResult<Fries> Get(int id)
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
        public ActionResult<Fries> Create([FromBody] Fries newFries)
        {
            try
            {
                return Ok(_service.Create(newFries));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Fries> Edit([FromBody] Fries editFries, int id)
        {
            try
            {
                editFries.Id = id;
                return Ok(_service.Edit(editFries));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Fries> Delete(int id)
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