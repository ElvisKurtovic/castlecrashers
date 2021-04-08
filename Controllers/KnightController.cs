using System;
using System.Collections.Generic;
using castlecrashers.Models;
using castlecrashers.Services;
using Microsoft.AspNetCore.Mvc;

namespace castlecrashers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KnightController : ControllerBase
    {

        private readonly KnightService _service;

        public KnightController(KnightService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Knight>> Get()
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
        public ActionResult<Knight> Get(int id)
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


        [HttpPost]
        public ActionResult<Knight> Create([FromBody] Knight newProd)
        {
            try
            {
                return Ok(_service.Create(newProd));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Knight> Edit([FromBody] Knight updated, int id)
        {
            try
            {
                updated.Id = id;
                return Ok(_service.Edit(updated));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Knight> Delete(int id)
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