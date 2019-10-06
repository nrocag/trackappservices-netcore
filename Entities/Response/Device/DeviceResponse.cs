using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Response.Device
{
    public class DeviceResponse
    {
        public DeviceResponse(Message message, bool success)
        {
            this.ActionResponse = new ActionResponse(message, success);
        }

        public DeviceResponse()
        {
        }

        public ActionResponse ActionResponse { get; protected set; }
    }
}
