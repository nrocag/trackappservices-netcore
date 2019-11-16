using Bussiness;
using Entities.Model;
using Entities.Response.Device;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace TrackAppService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        readonly IBussinessDevice bussiness;

        public DeviceController(IBussinessDevice bussiness)
        {
            this.bussiness = bussiness;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Device>>> Get()
        {
            ActionResult action;

            try
            {
                DeviceResponse response = await this.bussiness.GetAll();
                IEnumerable<Device> devices = (response as DeviceResponseQueryBySeveral).Devices;

                action = response.ActionResponse.Success ? this.Ok(devices) : (ActionResult)this.NotFound(response.ActionResponse.Message);
            }
            catch (System.Exception ex)
            {
                action = this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return action;
        }

        /// <summary>
        /// Obtiene el recurso solicitado buscando por el identificador.
        /// </summary>
        /// <param name="id">Identificador del recurso.</param>
        /// <returns>Recurso solicitado.</returns>
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
                DeviceResponse response = await this.bussiness.GetById(id);
                Device device = (response as DeviceResponseQueryByOne).Device;

                action = response.ActionResponse.Success ? this.Ok(device) : (ActionResult)this.NotFound(response.ActionResponse.Message);
            }
            catch (System.Exception ex)
            {
                action = this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return action;
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(Device device)
        {
            ActionResult action;

            try
            {
                if (this.ModelState.IsValid)
                {
                    DeviceResponse response = await this.bussiness.Create(device);

                    Uri urlGet = new Uri(string.Format("{0}{1}/{2}", this.Request.Host.Value, this.Request.Path, device._id));

                    action = this.Created(urlGet, response.ActionResponse.Message);
                }
                else
                {
                    action = this.Conflict(this.ModelState);
                }
            }
            catch (System.Exception ex)
            {
                action = this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return action;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(string id, Device device)
        {
            ActionResult action;

            try
            {
                if (this.ModelState.IsValid)
                {
                    DeviceResponse response = await this.bussiness.Update(id, device);

                    action = response.ActionResponse.Success ? this.Ok(response.ActionResponse.Message) : (ActionResult)this.BadRequest(response.ActionResponse.Message);
                }
                else
                {
                    action = this.Conflict(this.ModelState);
                }
            }
            catch (System.Exception ex)
            {
                action = this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return action;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(string id)
        {
            ActionResult action;

            try
            {
                DeviceResponse response = await this.bussiness.Delete(id);

                action = this.Ok(response.ActionResponse.Message);
            }
            catch (System.Exception ex)
            {
                action = this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return action;
        }
    }
}
