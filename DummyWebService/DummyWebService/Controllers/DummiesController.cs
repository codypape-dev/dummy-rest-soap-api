using System;
using System.Collections.Generic;
using DummyWebService.BusinessLogic;
using DummyWebService.Model;
using Microsoft.AspNetCore.Mvc;

namespace DummyWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummiesController : ControllerBase
    {
        DummiesBL dummyBL = new DummiesBL();

        // GET: api/Dummies
        /// <summary>
        /// Allows to get all Dummies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<Dummy>), 200)]
        public IEnumerable<Dummy> Get()
        {

            return dummyBL.GetDummies();
        }

        // GET: api/Dummies/5
        /// <summary>
        /// Allows to get a Dummy by an ID
        /// </summary>
        /// <param name="id">Dummy ID</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Dummy), 200)]
        public Dummy GetById(string id)
        {
            return dummyBL.GetDummyById(id);
        }

        // POST: api/Dummies
        /// <summary>
        /// Allows to create new Dummies
        /// </summary> 
        /// <param name="value">Dummy object</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Dummy), 201)]
        public IActionResult Post([FromBody] Dummy value)
        {

            Dummy result= dummyBL.Create(value);

            return Created(String.Format("api/{0}/{1}", "Dummies", result?.Id), result);
        }

        // PUT: api/Dummies/5
        /// <summary>
        /// Allows to update a Dummy by id
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>       
        /// <response code="200">Returns Dummy updated</response>
        [HttpPut]
        [ProducesResponseType(typeof(Dummy), 200)]
        public IActionResult Put([FromBody] Dummy value)
        {
            Dummy result = dummyBL.UpdateById(value);
            return Ok(result);
        }

        // DELETE api/Dummies/5
        /// <summary>
        /// Allows to delete Dummy by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>       
        /// <response code="200">Returns Dummy updated</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(dummyBL.DeleteDummyById(id));
        }
    }
}
