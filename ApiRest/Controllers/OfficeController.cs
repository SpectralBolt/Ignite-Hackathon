using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Services;
using Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IRepository repository;

        public OfficeController(IRepository repository)
        {
            this.repository = repository;
        }
        // GET: api/Office
        [HttpGet]
        public async Task<ActionResult<List<Office>>> Get()
        {
            var off = await repository.GetOfficesAsync();
            return off.ToList();
        }

        // GET: api/Office/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Office>> Get(int id)
        {
            return await repository.GetOffice(id);
        }

        // POST: api/Office
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Office/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
