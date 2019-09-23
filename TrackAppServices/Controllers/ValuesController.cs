namespace TrackAppServices.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TrackAppServices.DataBase;
    using TrackAppServices.Entities;

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IMongoRepository<Device> repository;

        public ValuesController(IMongoRepository<Device> repository)
        {
            this.repository = repository;
        }

        // GET api/values
        [HttpGet]
        public Task<IEnumerable<Device>> Get()
        {
            return this.repository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Task<Device> Get(string id)
        {
            return this.repository.GetOne(x => x._id.ToString().Equals(id));
        }

        // POST api/values
        [HttpPost]
        public void Post(Device device)
        {
            this.repository.InsertOne(device);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(string id, Device device)
        {
            this.repository.UpdateOne(x => x._id.ToString().Equals(id), device);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            this.repository.DeleteOne(x => x._id.ToString().Equals(id));
        }
    }
}
