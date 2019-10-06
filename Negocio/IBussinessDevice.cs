using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Entities.Model;
using Entities.Response.Device;

namespace Bussiness
{
    public interface IBussinessDevice
    {
        IMongoRepository<Device> Repository { get; set; }

        Task<DeviceResponse> Create(Device device);
        Task<DeviceResponse> Delete(string id);
        Task<DeviceResponse> GetAll();
        Task<DeviceResponse> GetById(string id);
        Task<DeviceResponse> Update(string id, Device device);
    }
}