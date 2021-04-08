using System;
using System.Collections.Generic;
using castlecrashers.Models;
using castlecrashers.Services;
using Microsoft.AspNetCore.Mvc;

namespace castlecrashers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CastleController : ControllerBase
    {

        private readonly CastleService _service;
        private readonly KnightService _ks;

        public CastleController(CastleService service, KnightService ks)
        {
            _service = service;
            _ks = ks;
        }

        [HttpGet]  // GETALL
        public ActionResult<IEnumerable<Castle>> Get()
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
        public ActionResult<Castle> Get(int id)
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
        public ActionResult<Castle> Create([FromBody] Castle newCastle)
        {
            try
            {
                return Ok(_service.Create(newCastle));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")] // PUT
        public ActionResult<Castle> Edit([FromBody] Castle editCastle, int id)
        {
            try
            {
                editCastle.Id = id;
                return Ok(_service.Edit(editCastle));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")] // DELETE
        public ActionResult<Castle> Delete(int id)
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

        [HttpGet("{id}/knight")]
        public ActionResult<IEnumerable<Knight>> GetKnights(int id)
        {
            try
            {
                return Ok(_ks.GetByCastleId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}