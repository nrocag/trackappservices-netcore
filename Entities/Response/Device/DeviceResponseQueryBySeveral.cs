using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Response.Device
{
    public class DeviceResponseQueryBySeveral : DeviceResponse
    {
        public DeviceResponseQueryBySeveral(IEnumerable<Model.Device> devices)
        {
            bool success = devices.Any();
            Message message = success ? Message.Message2 : Message.Message3;

            base.ActionResponse = new ActionResponse(message, success);
            this.Devices = devices;
        }

        public IEnumerable<Model.Device> Devices { get; private set; }
    }
}
