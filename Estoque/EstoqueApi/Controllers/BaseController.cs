using Data.model;
using Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<R, M> : ControllerBase where M : BaseModel where R : BaseRepository<M>
    {
        R repor = Activator.CreateInstance<R>();

        [HttpGet]
        public List<M> Get()
        {
            return repor.Read();
        }
        [HttpGet("{id}")]
        public M Get(int id)
        {
            return repor.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] M model)
        {
            repor.Create(model);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] M model)
        {
            repor.Update(model);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repor.Delete(id);
        }

    }
}
