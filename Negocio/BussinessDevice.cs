using Data;
using Entities.Model;
using Entities.Response;
using Entities.Response.Device;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bussiness
{
    public class BussinessDevice : IBussinessDevice
    {
        public IMongoRepository<Device> Repository { get; set; }

        public BussinessDevice()
        {
            this.Repository = new MongoRepository<Device>();
        }

        public async Task<DeviceResponse> GetAll()
        {
            IEnumerable<Device> devices = await this.Repository.GetAll();

            return new DeviceResponseQueryBySeveral(devices);
        }

        public async Task<DeviceResponse> GetById(string id)
        {
            Device device = await this.Repository.GetOne(id);

            return new DeviceResponseQueryByOne(device);
        }

        public async Task<DeviceResponse> Create(Device device)
        {
            await this.Repository.InsertOne(device);

            return new DeviceResponse(Message.Message1, true);
        }

        public async Task<DeviceResponse> Update(string id, Device device)
        {
            await this.Repository.UpdateOne(x => x._id.ToString().Equals(id), device);

            return new DeviceResponse(Message.Message1, true);
        }

        public async Task<DeviceResponse> Delete(string id)
        {
            await this.Repository.DeleteById(id);

            return new DeviceResponse(Message.Message4, true);
        }
    }
}
