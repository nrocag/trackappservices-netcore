using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Response.Device
{
    public class DeviceResponseQueryByOne : DeviceResponse
    {
        public DeviceResponseQueryByOne(Model.Device device)
        {
            bool success = device != null;
            Message message = success ? Message.Message2 : Message.Message3;

            base.ActionResponse = new ActionResponse(message, success);
            this.Device = device;
        }

        public Model.Device Device { get; private set; }
    }
}
