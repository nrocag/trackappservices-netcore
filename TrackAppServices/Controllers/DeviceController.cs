namespace TrackAppServices.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mime;
    using System.Threading.Tasks;
    using Bussiness;
    using Entities;

    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        readonly IMongoRepository<Device> repository;

        public DeviceController(IMongoRepository<Device> repository)
        {
            this.repository = repository;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Device>>> Get()
        {
            ActionResult action;

            try
            {
                IEnumerable<Device> devices = await this.repository.GetAll();
                action = devices.Count() > 0 ? Ok(devices) : (ActionResult)NotFound();
            }
            catch (System.Exception ex)
            {
                action = StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return action;
        }

        //private async IAsyncEnumerable<Device> GetDevices(IAsyncEnumerable<Device> devices)
        //{
        //    await foreach (var item in devices)
        //    {
        //        if (item.Category == 3)
        //        {
        //            yield return item;
        //        }
        //    }
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Device>> Get(string id)
        {
            ActionResult action;

            try
            {
                Device device = await this.repository.GetOne(x => x._id.Equals(id));

                action = device == null ? NotFound("Dispositivo no encontrado") : (ActionResult)Ok(device);
            }
            catch (System.Exception ex)
            {
                action = StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return action;
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(Device device)
        {
            ActionResult action;

            try
            {
                await this.repository.InsertOne(device);

                Uri urlGet = new Uri(string.Format("{0}{1}/{2}", this.Request.Host.Value, this.Request.Path, device._id));
                action = base.Created(urlGet, device);
            }
            catch (System.Exception ex)
            {
                action = StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return action;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Put(string id, Device device)
        {
            ActionResult action;

            try
            {
                this.repository.UpdateOne(x => x._id.ToString().Equals(id), device);

                action = Ok();
            }
            catch (System.Exception ex)
            {
                action = StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return action;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(string id)
        {
            ActionResult action;

            try
            {
                this.repository.DeleteOne(x => x._id.ToString().Equals(id));

                action = Ok();
            }
            catch (System.Exception ex)
            {
                action = StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return action;
        }
    }
}
